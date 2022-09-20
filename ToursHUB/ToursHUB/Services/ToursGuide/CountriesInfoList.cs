using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using ToursHUB.Models;
using ToursHUB.Models.ToursGuide;
using ToursHUB.Models.TourMedia;
using System.Collections.ObjectModel;
using ToursHUB.Extensions;

namespace ToursHUB.Services.ToursGuide
{
    public static class CountriesInfoList

    {


        public static List<Country> CountriesInfo = new List<Country>
        {
            new Country
            {
                Id = 1,
                Category = "Asia",
                Name = "Jordan",
                Details =
                    "Jordan, officially The Hashemite Kingdom of Jordan, is an Arab kingdom in Western Asia, on the East Bank of the Jordan River. Jordan is bordered by Saudi Arabia to the east and south; Iraq ",
                Image = {URL="http://www.switchmed.eu/en/country-hubs/images-country-hubs/1180x475_jordan.jpg" },
                Location = {Latitude=31.275760 , Longitude=36.828390 },
                IsFavourite = false,
                VedioIDs = new List<VedioID>
                {
                 new VedioID { VedioId= "yuADf7Ux3XM" },
                 new VedioID { VedioId= "TSZPRcruPL8" },
                 new VedioID { VedioId= "EcNerH87aKk" },
                 new VedioID { VedioId= "oCB1AViZ-p4" },
                 new VedioID { VedioId= "TahxKPAYutY" },
                 new VedioID { VedioId= "vVjz8LcOrEU" },
                 new VedioID { VedioId= "zHWDE8voj9M" },
                 new VedioID { VedioId= "bfmt7bDVibY" },
                 new VedioID { VedioId= "tqgqeLIq3rw" }
                },

         
               
                //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Cities =  CitiesInfoList.JordanCitiesInfo
            },



        new Country 
            {
                Id = 2,
                Category = "Asia",
                Name = "Iraq",
                Details =
                    "Iraq, officially The Hashemite Kingdom of Jordan, is an Arab kingdom in Western Asia, on the East Bank of the Jordan River. Jordan is bordered by Saudi Arabia to the east and south; Iraq ",
                Image = {URL="http://is5.mzstatic.com/image/thumb/Purple49/v4/96/fd/de/96fddef6-eebb-9a02-eb45-b5e66404cad7/source/512x512bb.jpg" },
                Location = {Latitude= 33.044832 , Longitude=43.773820 },
                IsFavourite = false,
                VedioIDs = new List<VedioID>
                {
                 new VedioID { VedioId= "jgzTWOSdzQ" },

                },

         
               
                //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Cities = CitiesInfoList.IraqCitiesInfo ,
        },
    };
    }


    public static class CitiesInfoList
    {
       


        public static List<City> IraqCitiesInfo = new List<City>
        {

            new City
            {
                Id = 1,
                Category = "Iraq",
                Name = "Bagdad",
                CountryId=2,
                Details =
                    "Bagdad is the capital and most populous city of Iraq",
                Image = {URL="http://2.bp.blogspot.com/-ZwgJ_iycB78/UYDZvMsCGwI/AAAAAAAAYrs/YRKXSPOpNs8/s1600/Iraq-Baghdad-Skyline.jpg" },
                Location = {Latitude=31.951800 , Longitude=35.940420 },
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="BJ84Y5fqiv0" },


                },
                //eventbriteEvents = new EventbriteEvents(),
               //foursquareVenues = new FoursquareVenues(),
               Distinations= DistinationsInfoList.DistinationsInfo,
            },
             new City
             {
                Id = 2,
                Category = "Iraq",
                Name = "Basra",
                CountryId=2,
                Details =
                    "Basra, known in ancient time City",
                Image = {URL= "http://ic2.pbase.com/o4/93/329493/1/59130994.Iraq2006020.jpg" },
                Location = {Latitude= 30.567651 , Longitude=47.749351 },
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="BJ84Y5fqiv0" },
                     
                     
                },
                //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo,

             },

             new City
             {
                Id = 3,
                Category = "Iraq",
                Name = "Samarraa",
                CountryId=2,
                Details =
                    "Samarraa is city of Samarraa Governorate in Iraq.",
                Image = {URL= "https://res.cloudinary.com/roadtrippers/image/upload/w_640,fl_progressive,q_60/v1408988621/vjd7mpyj6sasikucu67v.jpg" },
                Location = {Latitude= 34.198910, Longitude= 43.867310 },
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="jgzTWOSdzQ" },
                    
                     
                },
                 //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo,
             },
        };
      

        public static List<City> JordanCitiesInfo = new List<City>
        {

            new City
            {
                Id = 1,
                Category = "Jordan",
                Name = "Amman",
                CountryId=1,
                Details =
                    "Amman is the capital and most populous city of Jordan, and the country\'s economic, political and cultural centre. Situated in north-central Jordan, Amman is the administrative centre of the A…\r\n",
                Image = {URL="https://upload.wikimedia.org/wikipedia/commons/6/66/Amman.jpg" },
                Location = {Latitude=31.951800 , Longitude=35.940420 },
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="6mtWGzGvQas" },
                     new VedioID { VedioId= "nt1rGuAN2Qc" },
                     new VedioID { VedioId= "pHra-XIjz9A" },
                     new VedioID { VedioId= "7VXYITcIdZc" }
                   
                },
                 //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo,
            },
             new City
             {
                Id = 2,
                Category = "Jordan",
                Name = "Irbid",
                CountryId=1,
                Details =
                    "Irbid, known in ancient times as Arabella or Arbela, is the capital and largest city of the Irbid Governorate. It also has the second largest metropolitan population in Jordan after Amman, with a populat…\r\n",
                Image = {URL= "http://www.getmetravelled.com/wp-content/uploads/2015/10/Irbid-Jordan-2.jpg" },
                Location = {Latitude= 32.549230, Longitude=35.850920 },
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="GnrzL9EWlw0" },
                     new VedioID { VedioId= "lvHbEiN_LH4" },
                     new VedioID { VedioId= "v=rGMOlXmYv_M" },
                     new VedioID { VedioId= "jYS_85nfu60" }
                    
                },
                 //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo,
             },

             new City
             {
                Id = 3,
                Category = "Jordan",
                Name = "Mafraq",
                CountryId=1,
                Details =
                    "Mafraq is the capital city of Mafraq Governorate in Jordan, located 80 km to the north from the capital Amman in crossroad to Syria to the north and Iraq to the east. It has 58,954 inhabitants.",
                Image = {URL= "http://www.discoverjordan.co/site/images/map-mafraq.jpg" },
                Location = {Latitude= 32.341492, Longitude=36.202441 },
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="2v5P5ZinPFg" },
                     new VedioID { VedioId= "JtYSGd4e56o" }
                    
                    
                },

                 //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo,
             },

             new City
             {
                Id = 4,
                Category = "Jordan",
                Name = "Ajloun",
                CountryId=1,
                Details =
                    "Ajloun, also spelled Ajlun, is the capital town of the Ajloun Governorate, a hilly town in the north of Jordan, located 76 kilometers north west of Amman. It is noted for its impressive ruins of",
                Image = {URL= "http://www.atlastours.net/jordan.old/ajloun_castle.jpg" },
                Location = {Latitude= 32.332590, Longitude= 35.751930},
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="jusWXtd1Uow" },
                     new VedioID { VedioId= "rAbqY-1Ig4Y" }
                    
                },
                 //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo,
             },

            new City
             {
                Id = 5,
                Category = "Jordan",
                Name = "Maan",
                CountryId=1,
                Details =
                    "Ma'an is a city in southern Jordan, 218 kilometres southwest of the capital Amman. It serves as the capital of the Ma\'an Governorate. Its population is approximately 50,000. Civilizations …\r\n",
                Image = {URL= "https://velvetescape.com/wp-content/uploads/2011/12/ma-in-falls.jpg" },
                Location = {Latitude= 30.196400, Longitude= 35.730520},
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="YsmqM2ivPw0" },
                     new VedioID { VedioId= "By-eSd-NvzQ" },
                     new VedioID { VedioId= "Ms23lkHnDSM" },
                     new VedioID { VedioId= "jxchAA7ZjmU" }

                    
                },

                 //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo,
            },

            new City
            {
                Id = 6,
                Category = "Jordan",
                Name = "AlKarak",
                CountryId=1,
                Details =
                    "Al-Karak, also known as just Karak or Kerak, is a city in Jordan known for its Crusader castle, the Kerak Castle. The castle is one of the three largest castles in the region, the other two being in …\r\n",
                Image = {URL= "https://www.egypttoursplus.com/wp-content/uploads/2014/03/Ancient-crusader-castle-Al-Karak-Jordan.jpg" },
                Location = {Latitude= 31.173491, Longitude= 35.709862},
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="uL3CTqBHtcw" },
                     new VedioID { VedioId= "MO5sq1L5yHY" },
                     new VedioID { VedioId= "sxRnZkKHK0k" }

                     
                },
                 //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo,
            },

        new City
        {
                Id = 7,
                Category = "Jordan",
                Name = "Tafeleh",
                CountryId=1,
                Details =
                    "Tafilah is one of the governorates of Jordan, located about 180 km south-west of Amman, Jordan\'s capital. Tafilah Governorate is bordered by Karak Governorate to the north, Ma\'an Go…\r\n",
                Image = {URL= "https://t4.ftcdn.net/jpg/01/00/18/57/240_F_100185766_Xywn6C4QBKsx5azPbcu3kuXHHASVyPQM.jpg" },
                Location = {Latitude= 30.790060, Longitude= 35.691660},
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="HCX3muqvnEU" },
                     new VedioID { VedioId= "Oz_Ueju_DeQ" },

                  
                },
                 //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo,
        },


        new City
        {
                Id = 8,
                Category = "Jordan",
                Name = "Aqaba",
                CountryId=1,
                Details =
                    "Aqaba is the only coastal city in Jordan and the largest and most populous city on the Gulf of Aqaba. Situated in southernmost Jordan, Aqaba is the administrative centre of the Aqaba ",
                Image = {URL= "http://cruisediscover.com/iports/s980/1660-cruise-to-al-aqaba.jpg" },
                Location = {Latitude= 29.532020, Longitude= 35.006920},
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="jYdJA0FKI30" },
                     new VedioID { VedioId= "96hy6CFb1Ks" },
                     new VedioID { VedioId= "kUOn02nk3Ks" },
                     new VedioID { VedioId= "yLvqcqPhCHY" },
                     new VedioID { VedioId= "AqNIyKPSBzE" },
                     new VedioID { VedioId= "Hxo1JoDS41s" },

                  
                },

                 //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo,
        },


        new City
        {
                Id = 9,
                Category = "Jordan",
                Name = "Jerrash",
                CountryId=1,
                Details =
                    "Jerash, is the capital and the largest city of Jerash Governorate, Jordan, with a population of 50,745 as of 2015. Located 48 kilometres north of the capital of Jordan, Amman.\r\n",
                Image = {URL= "https://theplanetd.com/images/Jerash-amphitheater-jordan-1-L.jpg" },
                Location = {Latitude= 32.274850, Longitude= 35.895880},
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="QbYSG4cTVyg" },
                     new VedioID { VedioId= "eAUImWoiUas" },
                     new VedioID { VedioId= "CGdUIn102UE" },
                   
                    
                },
                 //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo,
        },


        new City
        {
                Id = 10,
                Category = "Jordan",
                Name = "Salt",
                CountryId=1,
                Details =
                    "Al-Salt is an ancient agricultural town and administrative centre in west-central Jordan. It is on the old main highway leading from Amman to Jerusalem. Situated in the Balqa highland, abo…\r\n",
                Image = {URL= "http://www.getmetravelled.com/wp-content/uploads/2015/10/Irbid-Jordan-2.jpg" },
                Location = {Latitude= 32.033000, Longitude= 35.733000},
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="3IvZxzkGcTM" },
                     new VedioID { VedioId= "91Xk_hic7js" },
                   
                     
                },

                 //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo,
        },


        new City
        {
                Id = 11,
                Category = "Jordan",
                Name = "Zarqa",
                CountryId=1,
                Details =
                    "The Blue City or Az-Zarqā is the capital of Zarqa Governorate in Jordan. Its name means \"the blue city\".\r\n",
                Image = {URL= "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/JHR_Az_Zarqa.jpg/800px-JHR_Az_Zarqa.jpg" },
                Location = {Latitude= 32.041150, Longitude= 36.081470},
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="n-SZAA0tSZk" },
                     new VedioID { VedioId= "9T-jWgXlOyU" },
                   
                    
                },
                 //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo,
        },

        new City
        {
                Id = 12,
                Category = "Jordan",
                Name = "Madaba",
                CountryId=1,
                Details =
                    "Madaba is the capital city of Madaba Governorate in central Jordan, with a population of about 60,000. It is best known for its Byzantine and Umayyad mosaics, especially a large Byzanti…\r\n",
                Image = {URL= "http://wonderstourism.com/wp-content/uploads/2013/05/Madaba-Jordan.jpg" },
                Location = {Latitude= 31.719010, Longitude= 35.792750},
                VedioIDs = new List<VedioID>
                {
                     new VedioID { VedioId="fBpXq6blKm8" },
                     new VedioID { VedioId= "73EJOjWiU8I" },
                   
                     
                },
                 //eventbriteEvents = new EventbriteEvents(),
                //foursquareVenues = new FoursquareVenues(),
                Distinations= DistinationsInfoList.DistinationsInfo, //to be Edited Later! Each City must Have its Own Distinations List! 
        },

        
        };


    }

    public static class DistinationsInfoList
    {
        public static List<Distination> DistinationsInfo = new List<Distination>
        {

            new Distination()
            {
                Category = "4d4b7104d754a06370d81259",
                Name = "Arts & Entertainment",
            },
            new Distination()
            {
                Category = "4bf58dd8d48988d181941735",
                Name = "Museum",
            },
            new Distination()
            {
                Category = "4bf58dd8d48988d182941735",
                Name = "Theme Park",

            },
            new Distination()
            {
                Category = "4d4b7105d754a06372d81259",
                Name = "College & University",
            },
            new Distination()
            {
                Category = "4d4b7105d754a06373d81259",
                Name = "Event",
            },
            new Distination ()
            {
                Category = "4d4b7105d754a06374d81259",
                Name = "Food",
            },
            new Distination()
            {
                Category = "4bf58dd8d48988d1e0931735",
                Name = "Coffee Shop",

            },

            new Distination()
            {
                Category = "4d4b7105d754a06377d81259",
                Name = "Outdoors & Recreation",

            },
        
            new Distination()
            {
                Category = "4d4b7105d754a06377d81259",
                Name = "Outdoors & Recreation",

            },
            new Distination()
            {
                Category = "4d4b7105d754a06375d81259",
                Name = "Professional & Other Distinations",

            },
            new Distination()
            {
                Category = "4bf58dd8d48988d104941735",
                Name = "Medical Center",

            },
            new Distination()
            {
                Category = "4bf58dd8d48988d12f941735",
                Name = "Library",

            },
            new Distination()
            {
                Category = "4bf58dd8d48988d172941735",
                Name = "Post Office",

            },

            new Distination()
            {
                Category = "4bf58dd8d48988d13b941735",
                Name = "School",

            },

            new Distination()
            {
                Category = "52e81612bcbc57f1066b7a33",
                Name = "Social Club",

            },

            new Distination()
            {
                Category = "4bf58dd8d48988d132941735",
                Name = "Church",

            },
            new Distination()
            {
                Category = "4bf58dd8d48988d138941735",
                Name = "Mosque",

            },
            new Distination()
            {
                Category = "4bf58dd8d48988d132941735",
                Name = "Church",

            },
            new Distination()
            {
                Category = "4bf58dd8d48988d13a941735",
                Name = "Temple",

            },

            new Distination()
            {
                Category = "4e67e38e036454776db1fb3a",
                Name = "Residence",

            },

            new Distination()
            {
                Category = "56aa371be4b08b9a8d5734c5",
                Name = "Wedding Hall",

            },

            new Distination()
            {
                Category = "4d4b7105d754a06378d81259",
                Name = "Shop & Service",

            },

            new Distination()
            {
                Category = "4d4b7105d754a06379d81259",
                Name = "Travel & Transport",

            },

            new Distination()
            {
                Category = "4bf58dd8d48988d1fa931735",
                Name = "Hotel",

            },

        };
    }

    //internal class VenuesInfoList
    //{
    //    public static List<FoursquareVenues> VenuesInfo = new List<FoursquareVenues>
    //    {
    //        new FoursquareVenues()
    //        {

    //        },
    //        new FoursquareVenues()
    //        {

    //        },
    //        new FoursquareVenues()
    //        {

    //        },
    //        new FoursquareVenues()
    //        {

    //        }
    //    };
    //}
}
