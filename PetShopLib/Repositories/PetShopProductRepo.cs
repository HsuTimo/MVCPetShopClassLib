using Dapper;
using Microsoft.Extensions.Configuration;
using PetShopLib.Interfaces;
using PetShopLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PetShopLib.Repositories
{
    public class PetShopProductRepo : IRepository<PetShopProduct>
    {
        private readonly IConfiguration _configuration;
        public PetShopProductRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Add(PetShopProduct obj)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductName", obj.ProductName);
            param.Add("@Quantity", obj.Quantity);
            param.Add("@Price", obj.Price);
            using (IDbConnection connection = new SqlConnection(Helper.Constr(_configuration, "DefaultConnection")))
            {
                connection.Execute("AddProduct", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteById(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id);
            using (IDbConnection connection = new SqlConnection(Helper.Constr(_configuration, "DefaultConnection")))
            {
                connection.Execute("DeleteProduct", param, commandType: CommandType.StoredProcedure);
            }
        }

        public List<PetShopProduct> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(Helper.Constr(_configuration, "DefaultConnection")))
            {
                var sql = $"select * from PetShopInventory";
                var output = connection.Query<PetShopProduct>(sql);
                return output.ToList();
            }
        }

        public PetShopProduct GetById(int id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.Constr(_configuration, "DefaultConnection")))
            {
                var sql = $"select * from PetShopInventory where ID = {id}";
                var output = connection.Query<PetShopProduct>(sql).First();
                return output;
            }
        }

        public void Update(PetShopProduct obj)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", obj.ID);
            param.Add("@ProductName", obj.ProductName);
            param.Add("@Quantity", obj.Quantity);
            param.Add("@Price", obj.Price);
            using (IDbConnection connection = new SqlConnection(Helper.Constr(_configuration, "DefaultConnection")))
            {
                connection.Execute("UpdateProduct", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
