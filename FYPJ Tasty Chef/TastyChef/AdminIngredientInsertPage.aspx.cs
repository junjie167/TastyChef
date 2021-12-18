using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class AdminIngredientInsertPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
          
                LblTotalCalories.Visible = false;
            }
            //If first time page is submitted and we have file in FileUpload control but not in session
            // Store the values to SEssion Object
            if (Session["FileUpload1"] == null && FileUploadImage.HasFile)
            {
                Session["FileUpload1"] = FileUploadImage;


            }
            // Next time submit and Session has values but FileUpload is Blank
            // Return the values from session to FileUpload
            else if (Session["FileUpload1"] != null && (!FileUploadImage.HasFile))
            {
                FileUploadImage = (FileUpload)Session["FileUpload1"];

            }
            // Now there could be another sictution when Session has File but user want to change the file
            // In this case we have to change the file in session object
            else if (FileUploadImage.HasFile)
            {
                Session["FileUpload1"] = FileUploadImage;

            }
        }

        protected void TbIngredientsName_TextChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            Ingredients i = new Ingredients();
            int result = 0;
            result = i.checkIngredientName(TbIngredientsName.Text);
            if (result > 0)
            {
                LblErrorMessage.Text = "Ingredient Name Exists";
                TbIngredientsName.Text = "";
            }
            else
            {
                LblErrorMessage.Text = "Available";
            }
        }

        //protected void TbProteins_TextChanged(object sender, EventArgs e)
        //{
        //    if (LblTotalCalories.Text == "")
        //    {
        //        decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //        LblTotalCalories.Text = Convert.ToString(proteinsCalories);
        //    }
        //    else if (LblTotalCalories.Text != "")
        //    {
        //        if (TbTotalFat.Text == "" && TbTotalCarbohydrates.Text == "")
        //        {
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //            LblTotalCalories.Text = Convert.ToString(proteinsCalories);
        //        }
        //        else if (TbTotalFat.Text != "")
        //        {
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalCalories = proteinsCalories + totalFatCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbTotalCarbohydrates.Text != "")
        //        {
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            decimal totalCalories = proteinsCalories + totalCarbohydrates;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbTotalFat.Text != "" && TbTotalCarbohydrates.Text != "")
        //        {
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalCalories = proteinsCalories + totalCarbohydrates + totalFatCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //    }
        //}

        //protected void TbSaturatedFat_TextChanged(object sender, EventArgs e)
        //{
        //    if (LblTotalCalories.Text == "" && TbTrans.Text == "")
        //    {
        //        decimal saturatedFatCalories = Convert.ToDecimal(TbSaturatedFat.Text) * 9;
        //        TbTotalFat.Text = TbSaturatedFat.Text;
        //        LblTotalCalories.Text = Convert.ToString(saturatedFatCalories);
        //    }

        //    else if (LblTotalCalories.Text != "" && TbTrans.Text == "" && TbProteins.Text != "" && TbTotalCarbohydrates.Text != "" && TbTotalFat.Text != "")
        //    {
        //        decimal saturatedFatCalories = Convert.ToDecimal(TbSaturatedFat.Text) * 9;
        //        TbTotalFat.Text = TbSaturatedFat.Text;
        //        LblTotalCalories.Text = Convert.ToString(saturatedFatCalories);
        //    }
        //    else if (TbProteins.Text != "" && TbTrans.Text == "")
        //    {
        //        decimal saturatedFatCalories = Convert.ToDecimal(TbSaturatedFat.Text) * 9;
        //        TbTotalFat.Text = TbSaturatedFat.Text;
        //        decimal totalProteins = Convert.ToDecimal(TbProteins.Text) * 4;
        //        decimal totalCalories = saturatedFatCalories + totalProteins;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }
        //    else if (TbTotalCarbohydrates.Text != "")
        //    {
        //        decimal saturatedFatCalories = Convert.ToDecimal(TbSaturatedFat.Text) * 9;
        //        TbTotalFat.Text = TbSaturatedFat.Text;
        //        decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //        decimal totalCalories = saturatedFatCalories + totalCarbohydrates;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }
        //    else if (TbTotalCarbohydrates.Text != "" && TbProteins.Text != "")
        //    {
        //        decimal saturatedFatCalories = Convert.ToDecimal(TbSaturatedFat.Text) * 9;
        //        TbTotalFat.Text = TbSaturatedFat.Text;
        //        decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //        decimal totalProteins = Convert.ToDecimal(TbProteins.Text) * 4;
        //        decimal totalCalories = saturatedFatCalories + totalCarbohydrates + totalProteins;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }


        //    else if (LblTotalCalories.Text != "")
        //    {


        //        if (TbTotalFat.Text == "" && TbTotalCarbohydrates.Text == "" && TbProteins.Text == "")
        //        {

        //            TbTotalFat.Text = TbSaturatedFat.Text;
        //            LblTotalCalories.Text = TbTotalFat.Text;
        //        }
        //        else if (TbTotalFat.Text != "" && TbTrans.Text != "")
        //        {

        //            decimal saturatedFatCalories = Convert.ToDecimal(TbSaturatedFat.Text) * 9;
        //            decimal transFatCalories = Convert.ToDecimal(TbTrans.Text) * 9;
        //            decimal totalFatCalories = transFatCalories + saturatedFatCalories;
        //            decimal saturatedFatG = Convert.ToDecimal(TbSaturatedFat.Text);
        //            decimal transFatG = Convert.ToDecimal(TbTrans.Text);
        //            decimal totalFat = saturatedFatG + transFatG;
        //            TbTotalFat.Text = Convert.ToString(totalFat);
        //            decimal totalCalories = totalFatCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);

        //        }
        //        else if (TbTotalCarbohydrates.Text != "")
        //        {
        //            decimal saturatedFatCalories = Convert.ToDecimal(TbSaturatedFat.Text) * 9;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            decimal totalCalories = saturatedFatCalories + totalCarbohydrates;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);

        //        }
        //        else if (TbProteins.Text != "")
        //        {
        //            decimal saturatedFatCalories = Convert.ToDecimal(TbSaturatedFat.Text) * 9;
        //            decimal totalProteins = Convert.ToDecimal(TbProteins.Text) * 4;
        //            decimal totalCalories = saturatedFatCalories + totalProteins;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbTotalFat.Text != "" && TbTotalCarbohydrates.Text != "")
        //        {
        //            decimal saturatedFatCalories = Convert.ToDecimal(TbSaturatedFat.Text) * 9;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            TbTotalFat.Text = TbSaturatedFat.Text;
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalCalories = saturatedFatCalories + totalCarbohydrates + totalFatCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbProteins.Text != "" && TbTotalFat.Text != "")
        //        {
        //            decimal transFatCalories = Convert.ToDecimal(TbTrans.Text) * 9;
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //            decimal transFat = Convert.ToDecimal(TbTrans.Text);
        //            decimal satruatedFat = Convert.ToDecimal(TbSaturatedFat.Text);
        //            decimal totalFat = satruatedFat + transFat;
        //            TbTotalFat.Text = Convert.ToString(totalFat);
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalCalories = proteinsCalories + totalFatCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbProteins.Text != "" && TbTotalCarbohydrates.Text != "")
        //        {
        //            decimal saturatedFatCalories = Convert.ToDecimal(TbSaturatedFat.Text) * 9;
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            decimal totalCalories = saturatedFatCalories + totalCarbohydrates + proteinsCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbProteins.Text != "" && TbTotalCarbohydrates.Text != "" && TbTotalFat.Text != "")
        //        {
        //            decimal saturatedFatCalories = Convert.ToDecimal(TbSaturatedFat.Text) * 9;
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            TbTotalFat.Text = TbSaturatedFat.Text;
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalCalories = saturatedFatCalories + totalCarbohydrates + proteinsCalories + totalFatCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //    }
        //}

        //protected void TbTrans_TextChanged(object sender, EventArgs e)
        //{
        //    if (LblTotalCalories.Text == "" && TbSaturatedFat.Text == "")
        //    {
        //        decimal transFatCalories = Convert.ToDecimal(TbTrans.Text) * 9;
        //        TbTotalFat.Text = TbSaturatedFat.Text;
        //        LblTotalCalories.Text = Convert.ToString(transFatCalories);
        //    }

        //    else if (LblTotalCalories.Text != "" && TbSaturatedFat.Text == "" && TbProteins.Text != "" && TbTotalCarbohydrates.Text != "" && TbTotalFat.Text != "")
        //    {
        //        decimal transFatCalories = Convert.ToDecimal(TbTrans.Text) * 9;
        //        TbTotalFat.Text = TbTrans.Text;
        //        LblTotalCalories.Text = Convert.ToString(transFatCalories);
        //    }
        //    else if (TbProteins.Text != "" && TbSaturatedFat.Text == "")
        //    {
        //        decimal transFatCalories = Convert.ToDecimal(TbTrans.Text) * 9;
        //        TbTotalFat.Text = TbTrans.Text;
        //        decimal totalProteins = Convert.ToDecimal(TbProteins.Text) * 4;
        //        decimal totalCalories = transFatCalories + totalProteins;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }
        //    else if (TbTotalCarbohydrates.Text != "")
        //    {
        //        decimal transFatCalories = Convert.ToDecimal(TbTrans.Text) * 9;
        //        TbTotalFat.Text = TbTrans.Text;
        //        decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //        decimal totalCalories = transFatCalories + totalCarbohydrates;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }
        //    else if (TbTotalCarbohydrates.Text != "" && TbProteins.Text != "")
        //    {
        //        decimal transFatCalories = Convert.ToDecimal(TbTrans.Text) * 9;
        //        TbTotalFat.Text = TbTrans.Text;
        //        decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //        decimal totalProteins = Convert.ToDecimal(TbProteins.Text) * 4;
        //        decimal totalCalories = transFatCalories + totalCarbohydrates + totalProteins;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }


        //    else if (LblTotalCalories.Text != "")
        //    {


        //        if (TbTotalFat.Text == "" && TbTotalCarbohydrates.Text == "" && TbProteins.Text == "")
        //        {

        //            TbTotalFat.Text = TbTrans.Text;
        //            LblTotalCalories.Text = TbTotalFat.Text;
        //        }
        //        else if (TbTotalFat.Text != "" && TbSaturatedFat.Text != "" && TbProteins.Text != "")
        //        {

        //            decimal transFat = Convert.ToDecimal(TbTrans.Text);
        //            decimal saturatedFat = Convert.ToDecimal(TbSaturatedFat.Text);
        //            decimal totalFat = saturatedFat + transFat;
        //            TbTotalFat.Text = Convert.ToString(totalFat);
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalProteins = Convert.ToDecimal(TbProteins.Text) * 4;
        //            decimal totalCalories = totalFatCalories + totalProteins;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);

        //        }
        //        else if (TbTotalCarbohydrates.Text != "")
        //        {
        //            decimal transFatCalories = Convert.ToDecimal(TbTrans.Text) * 9;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            decimal totalCalories = transFatCalories + totalCarbohydrates;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);

        //        }
        //        else if (TbProteins.Text != "" && TbSaturatedFat.Text != "")
        //        {
        //            decimal transFat = Convert.ToDecimal(TbTrans.Text);
        //            decimal saturatedFat = Convert.ToDecimal(TbSaturatedFat.Text);
        //            decimal totalFat = saturatedFat + transFat;
        //            TbTotalFat.Text = Convert.ToString(totalFat);
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalProteins = Convert.ToDecimal(TbProteins.Text) * 4;
        //            decimal totalCalories = totalFatCalories + totalProteins;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbTotalFat.Text != "" && TbTotalCarbohydrates.Text != "")
        //        {
        //            decimal transFatCalories = Convert.ToDecimal(TbTrans.Text) * 9;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            TbTotalFat.Text = TbTrans.Text;
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalCalories = transFatCalories + totalCarbohydrates + totalFatCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbProteins.Text != "" && TbTotalFat.Text != "")
        //        {
        //            decimal transFatCalories = Convert.ToDecimal(TbTrans.Text) * 9;
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //            decimal transFat = Convert.ToDecimal(TbTrans.Text);
        //            decimal satruatedFat = Convert.ToDecimal(TbSaturatedFat.Text);
        //            decimal totalFat = satruatedFat + transFat;
        //            TbTotalFat.Text = Convert.ToString(totalFat);
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalCalories = proteinsCalories + totalFatCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbProteins.Text != "" && TbTotalCarbohydrates.Text != "")
        //        {
        //            decimal transFatCalories = Convert.ToDecimal(TbTrans.Text) * 9;
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //            TbTotalFat.Text = TbTrans.Text;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            decimal totalCalories = transFatCalories + totalCarbohydrates + proteinsCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbProteins.Text != "" && TbTotalCarbohydrates.Text != "" && TbTotalFat.Text != "")
        //        {
        //            decimal transFatCalories = Convert.ToDecimal(TbTrans.Text) * 9;
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            TbTotalFat.Text = TbTrans.Text;
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalCalories = transFatCalories + totalCarbohydrates + proteinsCalories + totalFatCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //    }
        //}

        //protected void TbTotalFat_TextChanged(object sender, EventArgs e)
        //{
        //    if (LblTotalCalories.Text == "")
        //    {
        //        decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //        LblTotalCalories.Text = Convert.ToString(totalFatCalories);
        //    }
        //    else if (LblTotalCalories.Text != "")
        //    {
        //        if (TbProteins.Text == "" && TbTotalCarbohydrates.Text == "")
        //        {
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            LblTotalCalories.Text = Convert.ToString(totalFatCalories);
        //        }
        //        else if (TbProteins.Text != "")
        //        {
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;

        //            decimal totalCalories = proteinsCalories + totalFatCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbTotalCarbohydrates.Text != "")
        //        {
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            decimal totalCalories = totalFatCalories + totalCarbohydrates;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbProteins.Text != "" && TbTotalCarbohydrates.Text != "")
        //        {
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalCalories = proteinsCalories + totalCarbohydrates + totalFatCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //    }
        //}

        //protected void TbSugar_TextChanged(object sender, EventArgs e)
        //{
        //    if (TbTotalCarbohydrates.Text == "" && TbDietaryFiber.Text != "" && TbTotalFat.Text != "" && TbProteins.Text != "")
        //    {
        //        TbTotalCarbohydrates.Text = TbSugar.Text;
        //        decimal sugar = Convert.ToDecimal(TbSugar.Text);
        //        decimal totalCarb = Convert.ToDecimal(TbDietaryFiber.Text) + sugar;
        //        TbTotalCarbohydrates.Text = Convert.ToString(totalCarb);
        //        decimal totalCarbCalories = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //        decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //        decimal totalProteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //        decimal totalCalories = totalFatCalories + totalProteinsCalories + totalCarbCalories;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }
        //    else if (TbTotalCarbohydrates.Text != "" && TbDietaryFiber.Text != "" && TbTotalFat.Text != "" && TbProteins.Text != "")
        //    {
        //        TbTotalCarbohydrates.Text = TbSugar.Text;
        //        decimal sugar = Convert.ToDecimal(TbSugar.Text);
        //        decimal totalCarb = Convert.ToDecimal(TbDietaryFiber.Text) + sugar;
        //        TbTotalCarbohydrates.Text = Convert.ToString(totalCarb);
        //        decimal totalCarbCalories = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //        decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //        decimal totalProteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //        decimal totalCalories = totalFatCalories + totalProteinsCalories + totalCarbCalories;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }
        //    else if (TbTotalCarbohydrates.Text != "" && TbDietaryFiber.Text == "" && TbTotalFat.Text != "" && TbProteins.Text != "")
        //    {
        //        TbTotalCarbohydrates.Text = TbSugar.Text;
        //        decimal sugar = Convert.ToDecimal(TbSugar.Text);
        //        TbTotalCarbohydrates.Text = Convert.ToString(TbTotalCarbohydrates.Text);
        //        decimal totalCarbCalories = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //        decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //        decimal totalProteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //        decimal totalCalories = totalFatCalories + totalProteinsCalories + totalCarbCalories;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }
        //    else if (TbTotalCarbohydrates.Text == "" && TbDietaryFiber.Text == "" && TbTotalFat.Text != "" && TbProteins.Text != "")
        //    {
        //        TbTotalCarbohydrates.Text = TbSugar.Text;
        //        decimal sugar = Convert.ToDecimal(TbSugar.Text);

        //        decimal totalCarbCalories = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //        decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //        decimal totalProteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //        decimal totalCalories = totalFatCalories + totalProteinsCalories + totalCarbCalories;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }
        //}

        //protected void TbDietaryFiber_TextChanged(object sender, EventArgs e)
        //{
        //    if (TbTotalCarbohydrates.Text == "" && TbSugar.Text != "" && TbTotalFat.Text != "" && TbProteins.Text != "")
        //    {
        //        TbTotalCarbohydrates.Text = TbSugar.Text;
        //        decimal sugar = Convert.ToDecimal(TbSugar.Text);
        //        decimal totalCarb = Convert.ToDecimal(TbDietaryFiber.Text) + sugar;
        //        TbTotalCarbohydrates.Text = Convert.ToString(totalCarb);
        //        decimal totalCarbCalories = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //        decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //        decimal totalProteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //        decimal totalCalories = totalFatCalories + totalProteinsCalories + totalCarbCalories;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }
        //    else if (TbTotalCarbohydrates.Text != "" && TbSugar.Text != "" && TbTotalFat.Text != "" && TbProteins.Text != "")
        //    {
        //        TbTotalCarbohydrates.Text = TbSugar.Text;
        //        decimal sugar = Convert.ToDecimal(TbSugar.Text);
        //        decimal totalCarb = Convert.ToDecimal(TbDietaryFiber.Text) + sugar;
        //        TbTotalCarbohydrates.Text = Convert.ToString(totalCarb);
        //        decimal totalCarbCalories = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //        decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //        decimal totalProteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //        decimal totalCalories = totalFatCalories + totalProteinsCalories + totalCarbCalories;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }
        //    else if (TbTotalCarbohydrates.Text != "" && TbSugar.Text == "" && TbTotalFat.Text != "" && TbProteins.Text != "")
        //    {
        //        TbTotalCarbohydrates.Text = TbSugar.Text;
        //        decimal sugar = Convert.ToDecimal(TbSugar.Text);
        //        TbTotalCarbohydrates.Text = Convert.ToString(TbTotalCarbohydrates.Text);
        //        decimal totalCarbCalories = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //        decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //        decimal totalProteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //        decimal totalCalories = totalFatCalories + totalProteinsCalories + totalCarbCalories;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }
        //    else if (TbTotalCarbohydrates.Text == "" && TbSugar.Text == "" && TbTotalFat.Text != "" && TbProteins.Text != "")
        //    {
        //        TbTotalCarbohydrates.Text = TbSugar.Text;
        //        decimal sugar = Convert.ToDecimal(TbSugar.Text);

        //        decimal totalCarbCalories = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //        decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //        decimal totalProteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //        decimal totalCalories = totalFatCalories + totalProteinsCalories + totalCarbCalories;
        //        LblTotalCalories.Text = Convert.ToString(totalCalories);
        //    }
        //}

        //protected void TbTotalCarbohydrates_TextChanged(object sender, EventArgs e)
        //{
        //    if (LblTotalCalories.Text == "")
        //    {
        //        decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //        LblTotalCalories.Text = Convert.ToString(totalCarbohydrates);
        //    }
        //    else if (LblTotalCalories.Text != "")
        //    {
        //        if (TbProteins.Text == "" && TbTotalFat.Text == "")
        //        {
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            LblTotalCalories.Text = Convert.ToString(totalCarbohydrates);
        //        }
        //        else if (TbProteins.Text != "")
        //        {
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;

        //            decimal totalCalories = proteinsCalories + totalCarbohydrates;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbTotalFat.Text != "")
        //        {
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            decimal totalCalories = totalFatCalories + totalCarbohydrates;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //        else if (TbProteins.Text != "" && TbTotalFat.Text != "")
        //        {
        //            decimal proteinsCalories = Convert.ToDecimal(TbProteins.Text) * 4;
        //            decimal totalCarbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text) * 4;
        //            decimal totalFatCalories = Convert.ToDecimal(TbTotalFat.Text) * 9;
        //            decimal totalCalories = proteinsCalories + totalCarbohydrates + totalFatCalories;
        //            LblTotalCalories.Text = Convert.ToString(totalCalories);
        //        }
        //    }
        //}

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (DDLCategory.SelectedItem.Text != "Please Select")
            {
                string category = DDLCategory.SelectedItem.Text;
                string name = TbIngredientsName.Text;
                if (FileUploadImage.HasFile == true)
                {

                    string image = "Ingredients Images/" + FileUploadImage.FileName;
                    string remarks = TbRemarks.Text;
                    decimal proteins = Convert.ToDecimal(TbProteins.Text);
                    decimal pc = proteins * 4;

                    decimal sodium = Convert.ToDecimal(TbSodium.Text);
                    decimal cholesterol = Convert.ToDecimal(TbCholesterol.Text);

                    decimal saturatedFat = Convert.ToDecimal(TbSaturatedFat.Text);
                    decimal transFat = Convert.ToDecimal(TbTrans.Text);
                    decimal totalFat = Convert.ToDecimal(TbTotalFat.Text);
                    decimal cFat = totalFat * 9;

                    decimal sugar = Convert.ToDecimal(TbSugar.Text);
                    decimal dietaryFiber = Convert.ToDecimal(TbDietaryFiber.Text);
                    decimal carbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text);
                    decimal cc = carbohydrates * 4;

                    decimal totalCalories = pc + cFat + cc;
                    string measurement = DDlMeasure.SelectedItem.Text;
                    int result = 0;
                    Ingredients i = new Ingredients();
                    result = i.IngredientsInsert(name, image, category, remarks, proteins, sodium, carbohydrates, saturatedFat, transFat, totalFat, sugar, totalCalories, dietaryFiber, cholesterol, measurement);
                    if (result > 0)
                    {
                        Response.Redirect("AdminIngredientInsertPage.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Insert not Successfully');</script>");
                    }



                }

            }
            else
            {
                Response.Write("<script>alert('Please select a category');</script>");
            }
        }

        protected void BtnComputeCalories_Click(object sender, EventArgs e)
        {
            decimal proteins = Convert.ToDecimal(TbProteins.Text);
            decimal pc = proteins * 4;

            decimal sodium = Convert.ToDecimal(TbSodium.Text);
            decimal cholesterol = Convert.ToDecimal(TbCholesterol.Text);

            decimal saturatedFat = Convert.ToDecimal(TbSaturatedFat.Text);
            decimal transFat = Convert.ToDecimal(TbTrans.Text);
            decimal totalFat = Convert.ToDecimal(TbTotalFat.Text);
            decimal cFat = totalFat * 9;

            decimal sugar = Convert.ToDecimal(TbSugar.Text);
            decimal dietaryFiber = Convert.ToDecimal(TbDietaryFiber.Text);
            decimal carbohydrates = Convert.ToDecimal(TbTotalCarbohydrates.Text);
            decimal cc = carbohydrates * 4;

            decimal totalCalories = pc + cFat + cc;

            LblTotalCalories.Visible = true;
            LblTotalCalories.Text = Convert.ToString(totalCalories) +" " + "kcal";
        }
    }
}