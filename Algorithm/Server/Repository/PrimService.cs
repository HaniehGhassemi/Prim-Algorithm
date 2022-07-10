using System;
using Algorithm.Shared;
using Algorithm.Shared.Model;

namespace Algorithm.Server.Repositories
{
    public class PrimService
    {

        public List<Edge> Prim(int[,] w, int n)
        {
            int vnear = 0, min;
            List<Edge> F = new List<Edge>();

            int[] nearest = new int[n];
            int[] distance = new int[n];

            for (int i = 1; i < n; i++)
            {
                nearest[i] = 0;
                distance[i] = w[0, i];
            }

            for (int i = 1; i <= n - 1; i++) //repeat n-1
            {
                min = 1000000;
                for (int j = 1; j < n; j++)
                {
                    if (0 <= distance[j] && distance[j] < min)
                    {
                        min = distance[j];
                        vnear = j;
                    }

                }

                Edge e = new Edge()
                {
                    V1 = vnear,
                    V2 = nearest[vnear],
                    Cost = min
                };
                F.Add(e);
                distance[vnear] = -1;
                for (int z = 1; z < n; z++)
                {
                    if (w[z, vnear] < distance[z])
                    {
                        distance[z] = w[z, vnear];
                        nearest[z] = vnear;
                    }
                }

            }

            return F;

        }
    }
}

