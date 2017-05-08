using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing;
using PetronTrainingPortal.App_Code;
using System.Globalization;

public partial class Home_Onsite : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            using (var context = new DatabaseContext())
            {
                var trainingList = context.Trainings.Where(c => c.TrainingType == "Onsite").ToList();
                trainingList.Clear();
                int count = 0;
                foreach (var item in trainingList)
                {
                    count++;
                    string header = string.Empty;
                    string startMonth = string.Empty;
                    string extension = string.Empty;
                    int startDay = 0;
                    string dateEnd = string.Empty;
                  //extension = 

                    HtmlGenericControl mainDiv = new HtmlGenericControl("Div");
                    mainDiv.Attributes.Add("style", "commentBody");
                    mainDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#cbdbea");
                    mainDiv.Style.Add(HtmlTextWriterStyle.Color, "Black");
                    mainDiv.Style.Add(HtmlTextWriterStyle.Height, "100px");
                    mainDiv.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                    mainDiv.Style.Add(HtmlTextWriterStyle.MarginTop, "25px");

                    // create three labels and add them to the mainDiv
                    // 1,2,3 are the ordinal positions of the column names, this may need corrected since I have no idea what your table looks like.

                    startMonth = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(item.DateStart.Date.Month);
                    startDay = item.DateStart.Date.Day;
                    dateEnd = item.DateEnd.Date.ToString("MMMM dd, yyyy");
                    header = item.TrainingCode + ":" + item.TrainingTitle + "(" + startMonth + " " + startDay + "-" + dateEnd + ")";

                    HtmlGenericControl lblHeader = new HtmlGenericControl("Label");
                    lblHeader.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#cbdbea");
                    lblHeader.Style.Add(HtmlTextWriterStyle.Color, "#10253f");
                    lblHeader.Style.Add(HtmlTextWriterStyle.Height, "100px");
                    lblHeader.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                    lblHeader.Style.Add(HtmlTextWriterStyle.MarginTop, "15px");
                    lblHeader.Style.Add(HtmlTextWriterStyle.FontSize, "25px");
                    lblHeader.Style.Add(HtmlTextWriterStyle.FontFamily, "Corbel");
                    lblHeader.Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                    lblHeader.InnerHtml = header;
                    mainDiv.Controls.Add(lblHeader);
                    mainDiv.Controls.Add(new LiteralControl("<br />"));

                    HtmlGenericControl lblVenue = new HtmlGenericControl("Label");
                    lblVenue.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#cbdbea");
                    lblVenue.Style.Add(HtmlTextWriterStyle.Color, "Black");
                    lblVenue.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                    lblVenue.Style.Add(HtmlTextWriterStyle.Width, "10px");
                    lblVenue.InnerHtml = "Training Venue:";
                    mainDiv.Controls.Add(lblVenue);

                    HtmlGenericControl txtVenue = new HtmlGenericControl("Label");
                    txtVenue.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#cbdbea");
                    txtVenue.Style.Add(HtmlTextWriterStyle.Color, "Black");
                    txtVenue.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                    txtVenue.Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                    txtVenue.InnerHtml = item.Venue;
                    mainDiv.Controls.Add(txtVenue);
                    mainDiv.Controls.Add(new LiteralControl("<br />"));

                    HtmlGenericControl lblFacilitator = new HtmlGenericControl("Label");
                    lblFacilitator.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#cbdbea");
                    lblFacilitator.Style.Add(HtmlTextWriterStyle.Color, "Black");
                    lblFacilitator.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                    lblFacilitator.InnerHtml = "Facilitator:";
                    mainDiv.Controls.Add(lblFacilitator);

                    HtmlGenericControl txtFacilitator = new HtmlGenericControl("Label");
                    txtFacilitator.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#cbdbea");
                    txtFacilitator.Style.Add(HtmlTextWriterStyle.Color, "Black");
                    txtFacilitator.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                    txtFacilitator.Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                    txtFacilitator.InnerHtml = item.TrainingProvider;
                    mainDiv.Controls.Add(txtFacilitator);
                    mainDiv.Controls.Add(new LiteralControl("<br />"));

                    HtmlGenericControl lblTarget = new HtmlGenericControl("Label");
                    lblTarget.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#cbdbea");
                    lblTarget.Style.Add(HtmlTextWriterStyle.Color, "Black");
                    lblTarget.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                    lblTarget.InnerHtml = "Target Participants:";
                    mainDiv.Controls.Add(lblTarget);

                    HtmlGenericControl txtTarget = new HtmlGenericControl("Label");
                    txtTarget.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#cbdbea");
                    txtTarget.Style.Add(HtmlTextWriterStyle.Color, "Black");
                    txtTarget.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                    txtTarget.Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                    txtTarget.InnerHtml = item.TargetParticipants;
                    mainDiv.Controls.Add(txtTarget);
                    mainDiv.Controls.Add(new LiteralControl("<br />"));

                    HtmlGenericControl secondDiv = new HtmlGenericControl("Div");
                    secondDiv.Attributes.Add("style", "commentBody");
                    secondDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#cbdbea");
                    secondDiv.Style.Add(HtmlTextWriterStyle.Color, "Black");
                    secondDiv.Style.Add(HtmlTextWriterStyle.MarginLeft, "25px");
                    secondDiv.Style.Add(HtmlTextWriterStyle.MarginBottom, "5px");

                    LinkButton lnkAboutTraininer = new LinkButton();
                    lnkAboutTraininer.Text = "About The Trainer";
                    //link.Click += new System.EventHandler(LinkButtonTest_Click);
                    secondDiv.Controls.Add(lnkAboutTraininer);
                    secondDiv.Controls.Add(new Label() { Text = " | " });

                    LinkButton lnkCourseOutline = new LinkButton();
                    lnkCourseOutline.Text = "Course Outline";
                    //link.Click += new System.EventHandler(LinkButtonTest_Click);
                    secondDiv.Controls.Add(lnkCourseOutline);
                    secondDiv.Controls.Add(new Label() { Text = " | " });

                    LinkButton lnkBackground = new LinkButton();
                    lnkBackground.Text = "Backgound";
                                    //link.Click += new System.EventHandler(LinkButtonTest_Click);
                    secondDiv.Controls.Add(lnkBackground);
                    mainDiv.Controls.Add(secondDiv);

                    HtmlGenericControl lowerDiv = new HtmlGenericControl("Div");
                    lowerDiv.Attributes.Add("style", "commentBody");
                     lowerDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "White");
                    lowerDiv.Style.Add(HtmlTextWriterStyle.Color, "Black");
                    mainDiv.Controls.Add(lowerDiv);

                    HtmlGenericControl blueDiv = new HtmlGenericControl("Div");
                    blueDiv.Attributes.Add("style", "commentBody");
                    blueDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#5a8bda");
                    blueDiv.Style.Add(HtmlTextWriterStyle.Color, "Black");
                    blueDiv.Style.Add(HtmlTextWriterStyle.MarginLeft, "40px");
                    lowerDiv.Controls.Add(blueDiv);


                    Label lbl = new Label();
                    lbl.ForeColor = Color.White;
                    lbl.Font.Size = FontUnit.Small;
                    lbl.Style[HtmlTextWriterStyle.MarginRight] = "30px";
                    //link.Click += new System.EventHandler(LinkButtonTest_Click);
                    blueDiv.Controls.Add(lbl);

                    LinkButton lnkCheckOut = new LinkButton();
                    lnkCheckOut.Text = "Check Out";
                    lnkCheckOut.CommandName = item.TrainingCode;
                    lnkCheckOut.Attributes.Add("Style", "float: right");
                    lnkCheckOut.ForeColor = Color.White;
                    lnkCheckOut.Font.Size = FontUnit.Medium;
                    lnkCheckOut.Style[HtmlTextWriterStyle.MarginRight] = "20px";
                    //link.Click += new System.EventHandler(LinkButtonTest_Click);
                    blueDiv.Controls.Add(lnkCheckOut);

                    LinkButton lnkCart = new LinkButton();
                    lnkCart.Text = "Add to Shopping Cart";
                    lnkCart.CommandName = item.TrainingCode;
                    lnkCart.Attributes.Add("Style", "float: right");
                    lnkCart.ForeColor = Color.White;
                    lnkCart.Font.Size = FontUnit.Medium;
                    lnkCart.Style[HtmlTextWriterStyle.MarginRight] = "30px";
                    lnkCart.Click += new System.EventHandler(LinkButtonTest_Click);
                    blueDiv.Controls.Add(lnkCart);

                    // add the mainDiv to the page somehow, these can be added to any HTML control that can act as a container. I would suggest a plain old mainDiv.
                    menuPanel.Controls.Add(mainDiv);
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }

    }

    protected void LinkButtonTest_Click(object sender, EventArgs e)
    {
        LinkButton clickedButton = (LinkButton)sender;
        //Variables clickedButton.ID;
        Variables.OnsiteCode = clickedButton.CommandName;
        Response.Redirect("~/Home/Login.aspx");
    }
}