using System;
using System.Collections.Generic;

namespace Reto_Memoria
{
    public partial class Default : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Repeater rptCards;
        private const string SessionKey = "GameState";
        private static List<Card> Cards;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Card> cards = GenerateCards();
                rptCards.DataSource = cards;
                rptCards.DataBind();
            }
        }

        private void StartGame()
        {
            Cards = GenerateCards();
            Session[SessionKey] = Cards;
            rptCards.DataSource = Cards;
            rptCards.DataBind();
        }

        protected void btnRestart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private List<Card> GenerateCards()
        {
            var cards = new List<Card>
            {
                new Card { ID = 1, ImagePath = "Images/img1.jpg" },
                new Card { ID = 2, ImagePath = "Images/img2.jpg" },
                new Card { ID = 3, ImagePath = "Images/img3.jpg" },
                new Card { ID = 4, ImagePath = "Images/img4.jpg" },
                new Card { ID = 1, ImagePath = "Images/img1.jpg" },
            };

            return Shuffle(cards);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            StartGame();
        }
        private List<Card> Shuffle(List<Card> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public class Card
        {
            public int ID { get; set; }
            public string ImagePath { get; set; }
        }
    }
}