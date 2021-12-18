using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TastyChef
{
   
    public partial class CustomerRecipeRecommendation : System.Web.UI.Page
    {
        public static int num = 0;
        public static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                protein.Text = "0 Grams";
                fat.Text = "0 Grams";
                carbohydrate.Text = "0 Grams";
                calories.Text = "0";
                filter.Visible = false;
            }
            else
            {
                filter.Visible = true;
                int number = 0;
                for (int z = 0; z < schedule.Items.Count; z++)
                {
                    if (schedule.Items[z].Selected)
                    {
                        filter.Visible = true;
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        fliterlist.Controls.Add(li);
                        LinkButton link = new LinkButton();
                        link.ID = z.ToString() + count.ToString();
                        link.Text = schedule.Items[z].Value;
                        link.Click += new EventHandler(filterlink_Click);
                        li.Controls.Add(link);
                        number++;
                        num = number;
                    }
                }
                if (number < 1)
                {
                    filter.Visible = false;
                }
            }
            //if(result)
            //{
            //    if (Session["schedule"] != null)
            //    {
            //        filter.Visible = true;
            //        List<string> list = new List<string>();
            //        list = (List<string>)Session["schedule"];
            //        for (int n = 0; n < list.Count; n++)
            //        {
            //            filter.Visible = true;
            //            HtmlGenericControl li = new HtmlGenericControl("li");
            //            fliterlist.Controls.Add(li);
            //            LinkButton link = new LinkButton();
            //            link.ID = n.ToString()+count.ToString();                     
            //            link.Text = list[n] + " X";
            //            link.Click += new EventHandler(filterlink_Click);
            //            li.Controls.Add(link);
            //            //    for (int y = 0; y < schedule.Items.Count; y++)
            //            //    {
            //            //        if (schedule.Items[y].Value == list[n])
            //            //        {
            //            //            schedule.Items[y].Selected = true;

            //            //        }
            //            //    }

            //            //}
            //            //for (int z = 0; z < schedule.Items.Count; z++)
            //            //{
            //            //    if (schedule.Items[z].Selected)
            //            //    {
            //            //        filter.Visible = true;
            //            //        HtmlGenericControl li = new HtmlGenericControl("li");
            //            //        fliterlist.Controls.Add(li);
            //            //        HyperLink link = new HyperLink();
            //            //        link.ID = z.ToString();
            //            //        link.Text = schedule.Items[z].Value + " X";
            //            //        //Page.Controls.Add(link);
            //            //        //HtmlGenericControl anchor = new HtmlGenericControl("a");
            //            //        //anchor.Attributes.Add("href", "CustomerRecipeRecommendation.aspx");
            //            //        //anchor.Attributes.Add("runat", "server");
            //            //        //anchor.Attributes.Add("EnableViewState", "true");
            //            //        //anchor.InnerText = schedule.Items[z].Value + " X";
            //            //        //string schedulename = schedule.Items[z].Value;
            //            //        li.Controls.Add(link);
            //            //    }
            //            //    }
            //        }


            //    }


            //}
        }

        protected void schedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter.Visible = true;
            //int number = 0;
            //List<string> schedulelist = new List<string>();
            //for(int z = 0; z < schedule.Items.Count; z++)
            //{
            //    if (schedule.Items[z].Selected)
            //    {
            //        //filter.Visible = true;
            //        //HtmlGenericControl li = new HtmlGenericControl("li");
            //        //fliterlist.Controls.Add(li);
            //        //LinkButton link = new LinkButton();
            //        //link.ID = z.ToString() + num.ToString();
            //        //link.Text = schedule.Items[z].Value + " X";
            //        //link.Click += new System.EventHandler(filterlink_Click);
            //        //HtmlGenericControl anchor = new HtmlGenericControl("a");
            //        //anchor.Attributes.Add("href", "CustomerRecipeRecommendation.aspx");
            //        //anchor.Attributes.Add("runat", "server");
            //        //anchor.Attributes.Add("EnableViewState", "true");
            //        //anchor.InnerText = schedule.Items[z].Value + " X";
            //        string schedulename = schedule.Items[z].Value;
            //        //li.Controls.Add(link);
            //        schedulelist.Add(schedulename);
            //        num++;
            //        number++;
            //    }
            //}
            //if (number < 1)
            //{
            //    filter.Visible = false;
            //    result = false;
            //}
            //Session["Schedule"] = schedulelist;
        }

        public void filterlink_Click(object sender, EventArgs e)
        {

            LinkButton link = (LinkButton)sender;
            string linktext = link.Text;
            schedule_click(linktext);

        }

        protected void schedule_click(string filtername)
        {
            for (int w = 0; w < schedule.Items.Count; w++)
            {
                if (schedule.Items[w].Selected)
                {
                    if (schedule.Items[w].Value == filtername)
                    {
                        schedule.Items[w].Selected = false;
                        if (w <= num)
                        {
                            if(w != 0){
                                int o = w - 1;
                                fliterlist.Controls.RemoveAt(o);
                            }else
                            {
                                
                                fliterlist.Controls.RemoveAt(w);
                            }
                        }
                        else
                        {
                            int m = w - num;
                            if (m < num)
                            {
                                fliterlist.Controls.RemoveAt(m);
                            }
                            else
                            {
                                num--;
                                fliterlist.Controls.RemoveAt(num);
                            }
                        }

                    }
                }
            }
            Boolean result = false;
            for (int t = 0; t < schedule.Items.Count; t++)
            {
                if (schedule.Items[t].Selected)
                {
                    result = true;
                }
            }
            if (result == false)
            {
                filter.Visible = false;
            }

        }

        protected void clear_Click(object sender, EventArgs e)
        {
            for(int u = 0; u < schedule.Items.Count; u++)
            {
                if (schedule.Items[u].Selected)
                {
                    schedule.Items[u].Selected = false;
                }
            }
            filter.Visible = false;
        }
    }
}