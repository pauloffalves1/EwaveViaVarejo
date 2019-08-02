using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ViaVarejo.Services.Friends.Domain;
using ViaVarejo.Services.Friends.Domain.Interfaces;
using ViaVarejo.Services.Friends.Infrastructure.Context;

namespace ViaVarejo.Services.Friends.Infrastructure.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        ViaVarejoDBContext db;
        IConfiguration config;

        public FriendRepository(ViaVarejoDBContext _db, IConfiguration _config)
        {
            db = _db;
            config = _config;
        }

        public async Task<int> AddFriend(Friend friend)
        {
            if (db != null)
            {
                await db.Friend.AddAsync(friend);
                await db.SaveChangesAsync();

                return friend.Id;
            }

            return 0;
        }

        public async Task<int> DeleteFriend(int? friendId)
        {
            int result = 0;

            if (db != null)
            {
                var friend = await db.Friend.FirstOrDefaultAsync(x => x.Id == friendId);

                if (friend != null)
                {
                    db.Friend.Remove(friend);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<Friend> GetFriend(int? friendId)
        {
            if (db != null)
            {
                return await db.Friend.FirstOrDefaultAsync(x => x.Id == friendId);
            }

            return null;
        }

        public async Task<List<Friend>> GetFriends()
        {
            if (db != null)
            {
                return await db.Friend.ToListAsync();
            }

            return null;
        }

        public async Task UpdateFriend(Friend friend)
        {
            if (db != null)
            {
                db.Friend.Update(friend);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TreeFriends>> GetThreeClosestFriends(int id)
        {
            Friend fullfriend = await GetFriend(id);

            IEnumerable<TreeFriends> retorno;

            using (SqlConnection conexao = new SqlConnection(
                config.GetConnectionString("ViaVarejoDBConnection")))
            {
                StringBuilder sql = new StringBuilder();

                sql.Append(" DECLARE @S GEOGRAPHY; ");
                sql.Append(" SET @S = GEOGRAPHY::STGeomFromText('POINT(" + fullfriend.Latitude.ToString() + " " + fullfriend.Longitude.ToString() + ")', 4326) ");
                sql.Append(" SELECT TOP 3 ID, NAME, ");
                sql.Append("        @S.STDistance(GEOGRAPHY::STGeomFromText('POINT(' + CONVERT(VARCHAR,LATITUDE) + ' ' + CONVERT(VARCHAR,LONGITUDE) +')' , 4326))/1000 AS DISTANCE");
                sql.Append(" FROM FRIEND ");
                sql.Append(" WHERE ID != " + fullfriend.Id.ToString());
                sql.Append(" ORDER BY DISTANCE ");

                retorno = await conexao.QueryAsync<TreeFriends>(sql.ToString());
            }

            return retorno;
        }
    }
}
