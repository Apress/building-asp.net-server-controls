// Title: Building ASP.NET Server Controls
//
// Chapter: 13 - Deploying Controls
// File: Pager.cs
// Written by: Dale Michalk and Rob Cameron
//
// Copyright © 2003, Apress L.P.

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Reflection;
using System.ComponentModel;
using System.Resources;

namespace Apress.GoogleControls
{
   /// <summary>
   /// Pager control implements the paging functionality aggregated
   /// by the Result control
   /// </summary>
   internal class Pager : WebControl, INamingContainer
   {
      private const string GoogleNavPreviousImageUrl = "http://www.google.com/nav_previous.gif";
      private const string GoogleNavFirstImageUrl = "http://www.google.com/nav_first.gif";
      private const string GoogleNavNextImageUrl = "http://www.google.com/nav_next.gif";
      private const string GoogleNavPageImageUrl = "http://www.google.com/nav_page.gif";
      private const string GoogleNavCurrentImageUrl = "http://www.google.com/nav_current.gif";
      private const string GoogleNavLastImageUrl = "http://www.google.com/nav_last.gif";

      private Table table;
      private ResultPagerLinkStyle pagerLinkStyle;
      private int pagerBarRange;
      private int pageSize;
      private int startIndex;
      private int endIndex;
      private int totalResultsCount;

      /// <summary>
      /// Pager is based on span tag
      /// </summary>
      protected override HtmlTextWriterTag TagKey
      {
         get
         {
            return HtmlTextWriterTag.Span;
         }
      }

      /// <summary>
      /// Number of search results returned with query and displayed on page.
      /// </summary>
      public int PageSize
      {
         get
         {
            return pageSize;
         }
         set
         {
            pageSize = value;
         }
      }

      /// <summary>
      /// Number of pages displayed in pager bar.
      /// </summary>
      public int PagerBarRange
      {
         get
         {
            return pagerBarRange;
         }
         set
         {
            pagerBarRange = value;
         }
      }

      /// <summary>
      /// Style of Pager control link display.
      /// </summary>
      public ResultPagerLinkStyle PagerLinkStyle
      {
         get
         {
            return pagerLinkStyle;
         }
         set
         {
            pagerLinkStyle = value;
         }
      }

      /// <summary>
      /// Starting item index of search results.
      /// </summary>
      public int StartIndex
      {
         get
         {
            return startIndex;
         }
         set
         {
            startIndex = value;
         }
      }

      /// <summary>
      /// Ending item index of search list results.
      /// </summary>
      public int EndIndex
      {
         get
         {
            return endIndex;
         }
         set
         {
            endIndex = value;
         }
      }

      /// <summary>
      /// Estimated total results count from query.
      /// </summary>
      public int TotalResultsCount
      {
         get
         {
            return totalResultsCount;
         }
         set
         {
            totalResultsCount = value;
         }
      }

      private void CreatePagerResults(TableRow imageRow, TableRow textRow,
         ResultPagerLinkStyle style)
      {
         TableCell cell;
         if (style == ResultPagerLinkStyle.TextWithImages)
         {
            cell = new TableCell();
            cell.Text = "&nbsp;";
            imageRow.Cells.Add(cell);
         }

         cell = new TableCell();

         ResourceManager rm = ResourceFactory.Manager;

         cell.Text = rm.GetString("Pager.resultsPageCell.Text");
         cell.Wrap = false;
         cell.HorizontalAlign = HorizontalAlign.Center;
         textRow.Cells.Add(cell);
      }

      private void CreatePagerFirstImage(TableRow imageRow, TableRow textRow)
      {
         TableCell cell = new TableCell();
         cell.HorizontalAlign = HorizontalAlign.Left;
         Image lastImg = new Image();
         lastImg.ImageUrl = GoogleNavFirstImageUrl;
         cell.Controls.Add(lastImg);
         imageRow.Cells.Add(cell);

         cell = new TableCell();
         cell.Text = "&nbsp;";
         textRow.Cells.Add(cell);
      }

      private void CreatePagerPreviousButton(TableRow imageRow, TableRow textRow,
         ResultPagerLinkStyle style, int prevIndex)
      {

         TableCell cell;

         if (style == ResultPagerLinkStyle.TextWithImages)
         {
            cell = new TableCell();
            ImageButton prevImgButton = new ImageButton();
            prevImgButton.ImageUrl = GoogleNavPreviousImageUrl;
            prevImgButton.CommandName = "Page";
            prevImgButton.CommandArgument = prevIndex.ToString();

            cell.Controls.Add(prevImgButton);
            imageRow.Cells.Add(cell);
         }

         ResourceManager rm = ResourceFactory.Manager;

         cell = new TableCell();
         LinkButton prevButton = new LinkButton();
         prevButton.ID = "PrevButton";
         prevButton.Text = rm.GetString("Pager.prevButton.Text");
         prevButton.CommandName = "Page";
         prevButton.CommandArgument = prevIndex.ToString();
         cell.HorizontalAlign = HorizontalAlign.Right;
         cell.Controls.Add(prevButton);

         textRow.Cells.Add(cell);
      }

      private void CreatePagerPageButton(TableRow imageRow, TableRow textRow,
         ResultPagerLinkStyle style, int pageNum, int pageIndex, bool currentPage)
      {
         TableCell cell;
         LiteralControl lit;

         if (style == ResultPagerLinkStyle.TextWithImages)
         {
            cell = new TableCell();
            ImageButton pageImgButton = new ImageButton();
            pageImgButton.Width = 16;
            if (currentPage == true)
               pageImgButton.ImageUrl = GoogleNavCurrentImageUrl;
            else
               pageImgButton.ImageUrl = GoogleNavPageImageUrl;

            pageImgButton.CommandName = "Page";
            pageImgButton.CommandArgument = pageIndex.ToString();

            cell.Controls.Add(pageImgButton);
            imageRow.Cells.Add(cell);
         }

         cell = new TableCell();
         cell.HorizontalAlign = HorizontalAlign.Center;

         // add extra separation between page numbers
         // if text only paging is used
         if (style == ResultPagerLinkStyle.Text)
         {
            lit = new LiteralControl();
            lit.Text = "&nbsp;";
            cell.Controls.Add(lit);
         }

         LinkButton pageButton = new LinkButton();
         pageButton.ID = "page" + pageIndex.ToString() + "Button";
         pageButton.Text = pageNum.ToString();
         pageButton.CommandName = "Page";
         pageButton.CommandArgument = pageIndex.ToString();
         pageButton.CausesValidation = true;
         if (currentPage == true)
            pageButton.ControlStyle.Font.Bold = true;

         cell.Controls.Add(pageButton);
         textRow.Cells.Add(cell);
      }

      private void CreatePagerNextButton(TableRow imageRow, TableRow textRow,
         ResultPagerLinkStyle style, int nextIndex)
      {
         TableCell cell = new TableCell();
         LiteralControl lit;

         if (style == ResultPagerLinkStyle.TextWithImages)
         {
            cell = new TableCell();
            cell.HorizontalAlign = HorizontalAlign.Left;
            ImageButton nextImgButton = new ImageButton();
            nextImgButton.ImageUrl = GoogleNavNextImageUrl;
            nextImgButton.CommandName = "Page";
            nextImgButton.CommandArgument = nextIndex.ToString();

            cell.Controls.Add(nextImgButton);
            imageRow.Cells.Add(cell);
         }

         cell = new TableCell();

         // add extra separation between page numbers
         // if text only paging is used
         if (style == ResultPagerLinkStyle.Text)
         {
            lit = new LiteralControl();
            lit.Text = "&nbsp;";
            cell.Controls.Add(lit);
         }

         ResourceManager rm = ResourceFactory.Manager;

         LinkButton nextButton = new LinkButton();
         nextButton.ID = "nextButton";
         nextButton.Text = rm.GetString("Pager.nextButton.Text");
         nextButton.CommandName = "Page";
         nextButton.CommandArgument = nextIndex.ToString();
         cell.HorizontalAlign = HorizontalAlign.Center;
         cell.Controls.Add(nextButton);

         textRow.Cells.Add(cell);
      }

      private void CreatePagerLastImage(TableRow imageRow, TableRow textRow)
      {
         TableCell cell = new TableCell();
         cell.HorizontalAlign = HorizontalAlign.Left;
         Image lastImg = new Image();
         lastImg.ImageUrl = GoogleNavLastImageUrl;
         cell.Controls.Add(lastImg);
         imageRow.Cells.Add(cell);

         cell = new TableCell();
         cell.Text = "&nbsp;";
         textRow.Cells.Add(cell);
      }

      private void CreateControlHierarchy()
      {
         table = new Table();

         TableRow imageRow = new TableRow();
         imageRow.VerticalAlign = VerticalAlign.Bottom;

         TableRow textRow = new TableRow();
         textRow.VerticalAlign = VerticalAlign.Top;

         // insert localized "Page Results:" text
         CreatePagerResults(imageRow, textRow, PagerLinkStyle);

         // calculate the total number of pages based on the
         // page size and the TotalResultsCount from the
         // search service query
         int numPages = (int) System.Math.Ceiling(
            (double) TotalResultsCount / PageSize);

         // Since the TotalResultsCount is not infallible
         // for calculating bounding of the size of a
         // result set...check to see that a page's worth
         // of data is coming back with each request.
         // If the ending index of that result is less than
         // the TotalResultsCount, you know there is a shortage
         // in what Google will give you.
         if (EndIndex - StartIndex < PageSize - 1 &&
            EndIndex < TotalResultsCount)
         {
            // if so...recalc page number on EndIndex value
            // instead of the estimated count
            numPages = (int) System.Math.Ceiling(
               (double) EndIndex / PageSize);
         }


         int currentPage = (int) System.Math.Floor(
            (double) StartIndex / PageSize) + 1;

         // if the page number greater than 1 you can put in a previous page
         // link
         if (currentPage > 1)
         {
            // use indexes of the result items as the value of the
            // navigation (bounded at zero of course)
            int prevIndex = StartIndex - PageSize;
            if (prevIndex < 0)
               prevIndex = 0;

            // insert Previous text and Google image with left arrow
            CreatePagerPreviousButton(imageRow, textRow, PagerLinkStyle, prevIndex);
         }
         else if (PagerLinkStyle == ResultPagerLinkStyle.TextWithImages)
         {
            CreatePagerFirstImage(imageRow, textRow);
         }

         // calculate starting and ending pages for the
         // page index links (bound at 1 and max pages)
         int startPage = currentPage - pagerBarRange;
         if (startPage < 1)
            startPage = 1;
         int endPage = currentPage + pagerBarRange;
         if (endPage > numPages)
            endPage = numPages;


         // loop through each page and spit out the page link
         for (int pageNum = startPage; pageNum <= endPage; pageNum++)
         {
            // result index number is used for navigation to
            // specific page
            int pageIndex = ((pageNum - 1) * PageSize);

            // insert Page number text and Google O image
            CreatePagerPageButton(imageRow, textRow, PagerLinkStyle,
               pageNum, pageIndex,
               (currentPage == pageNum));
         }

         // insert a next link if less than max number of pages
         if (currentPage < numPages)
         {
            // calculate the next index to link to
            // (bounded by totalresultscount)
            int nextIndex = StartIndex + PageSize;
            if (nextIndex > TotalResultsCount)
               nextIndex = TotalResultsCount;

            // insert Next text and Google image with right arrow
            CreatePagerNextButton(imageRow, textRow, PagerLinkStyle, nextIndex);
         }
            // if there is no next button, insert the trailing
            // Google image without a right arrow
         else if (PagerLinkStyle == ResultPagerLinkStyle.TextWithImages)
         {
            CreatePagerLastImage(imageRow, textRow);
         }

         // only add the image row links if we have selected them
         // for paging
         if (PagerLinkStyle == ResultPagerLinkStyle.TextWithImages)
         {
            table.Rows.Add(imageRow);
         }

         // always display text links
         table.Rows.Add(textRow);

         Controls.Add(table);
      }

      /// <summary>
      /// Called by framework for composite controls to create control heirarchy
      /// </summary>
      override protected void CreateChildControls()
      {
         Controls.Clear();
         CreateControlHierarchy();
      }

      /// <summary>
      /// Overridden to ensure Controls collection is created before external access
      /// </summary>
      public override ControlCollection Controls
      {
         get
         {
            EnsureChildControls();
            return base.Controls;
         }
      }

      protected void PrepareControlHierarchy()
      {
         // apply the Pager style attributes to the
         // table if they were specified by Result control
         if (this.ControlStyleCreated)
            table.ApplyStyle(this.ControlStyle);
      }

      /// <summary>
      /// Overridden to ensure styles are properly applied
      /// </summary>
      protected override void RenderContents(HtmlTextWriter writer)
      {
         EnsureChildControls();

         PrepareControlHierarchy();

         base.RenderContents (writer);
      }
   }
}