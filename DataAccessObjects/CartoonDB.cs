using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;

namespace DataAccessObjects
{
    public class CartoonDB
    {
        private static List<CartoonModel> ModelList = new List<CartoonModel>() {
        
            new CartoonModel()
            {
                CartoonID = 0,
                CartoonName = "phim hoat hinh so 1 vn",
                CartoonType = "Action",
                Actor = "1 minh tao",
                Director = "tao",
                Country = "le amx",
                Duration = 15,
                LaunchDate = "1/1/2000",
                Producer = "van la tao",
                ShortDescripition = "phim hoat hinh so 1 viet nam khong ai co the sang bang",
            },
            new CartoonModel()
            {
                CartoonID = 1,
                CartoonName = "Kancolle",
                CartoonType = "Cartoon Musical",
                Actor = "Yukikaze",
                Director = "Tanaka",
                Country = "Japan",
                Duration = 180,
                LaunchDate = "5/7/2018",
                Producer = "Kadokawa",
                ShortDescripition = "phim tau chien ban nhau bum bum",
            }

        };

        private static CartoonDB instance = null;
        private static readonly object instanceLock = new object();
        private CartoonDB() { }
        public static CartoonDB Instance
        {
            get {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CartoonDB();
                    }
                    return instance;
                }
               
                }
        }

        public List<CartoonModel> GetCartoonList => ModelList;

        public CartoonModel GetCartoonModelByID(int CartoonID)
        {
            CartoonModel cartoon = ModelList.SingleOrDefault(pro => pro.CartoonID == CartoonID);
            return cartoon;
        }


        public void Create(CartoonModel cartoon)
        {
            CartoonModel model = GetCartoonModelByID (cartoon.CartoonID);
            if (model == null)
            {
                ModelList.Add(cartoon);
            } else
            {
                throw new Exception("[Add failed] CartoonID already exist");
            }

        }

        public void Update(CartoonModel cartoon)
        {
            CartoonModel model = GetCartoonModelByID(cartoon.CartoonID);
            if (model != null)
            {
                var index = ModelList.IndexOf (model);
                ModelList[index] = cartoon;
            }else
            {
                throw new Exception("[Update failed] Cartoon not found");
            }
        }

        public void Remove(int CartoonID)
        {
            CartoonModel model = GetCartoonModelByID (CartoonID);
            if (model != null)
            {
                ModelList.Remove(model);
            } else
            {
                throw new Exception("[Delete failed] Cartoon not found");
            }
        }
    }
}
