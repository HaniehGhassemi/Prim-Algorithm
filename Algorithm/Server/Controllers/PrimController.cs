using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithm.Server;
using Algorithm.Server.Repositories;
using Algorithm.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algorithm.Server.Controllers
{
    [Route("api/[controller]")]
    public class PrimController : Controller
    {
        [HttpPost("prim")]
        public async Task<Dto> PrimAlgorithm([FromBody]List<int[]> w , int n)
        {
            int[,] X = new int[n, n];
            foreach (var item in w)
            {
                for (int i = 0; i < n; i++)
                {
                    X[w.IndexOf(item), i] = item[i];
                }
            }

            PrimService graph = new PrimService();
            var output = graph.Prim(X, n);
            Dto my= new Dto { Count=n,edges=output};
            return my;
            
            
  
            
        }
    }
}

