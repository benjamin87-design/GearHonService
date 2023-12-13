using ClosedXML.Excel;

namespace GearHonService.ViewModels
{
	public partial class ServiceReportViewModel : BaseViewModel
	{
		public ServiceReportViewModel()
		{

		}

		public void CreateExcelFile(string filePath)
		{
			using (var workbook = new XLWorkbook())
			{
				var worksheet = workbook.Worksheets.Add("Servicereport");

				//set column width from A to R to one size
				for (char column = 'A'; column <= 'Q'; column++)
				{
					worksheet.Column(column.ToString()).Width = 10;
				}

				//set column width for column R
				worksheet.Column("R").Width = 20;

				//merge cells 
				var titlemerge = worksheet.Range("A1:R1");
				titlemerge.Merge();

				//merge spacer cells
				var spacermerge1 = worksheet.Range("A2:R2");
				spacermerge1.Merge();
				var spacermerge2 = worksheet.Range("A7:R7");
				spacermerge2.Merge();
				var spacermerge3 = worksheet.Range("A12:R12");
				spacermerge3.Merge();
				var spacermerge4 = worksheet.Range("A21:R21");
				spacermerge4.Merge();
				var spacermerge5 = worksheet.Range("A25:R25");
				spacermerge5.Merge();
				var spacermerge6 = worksheet.Range("A40:R40");
				spacermerge6.Merge();
				var spacermerge7 = worksheet.Range("A48:R48");
				spacermerge7.Merge();
				var spacermerge8 = worksheet.Range("A51:R51");
				spacermerge8.Merge();

				//merge cells for header left
				var headerleftmerge = worksheet.Range("A3:C3");
				headerleftmerge.Merge();
				var headerleftmerge2 = worksheet.Range("A4:C4");
				headerleftmerge2.Merge();
				var headerleftmerge3 = worksheet.Range("A5:C5");
				headerleftmerge3.Merge();
				var headerleftmerge4 = worksheet.Range("A6:C6");
				headerleftmerge4.Merge();

				var headerleftmerge5 = worksheet.Range("D3:I3");
				headerleftmerge5.Merge();
				var headerleftmerge6 = worksheet.Range("D4:I4");
				headerleftmerge6.Merge();
				var headerleftmerge7 = worksheet.Range("D5:I5");
				headerleftmerge7.Merge();
				var headerleftmerge8 = worksheet.Range("D6:I6");
				headerleftmerge8.Merge();

				//merge cells for header right
				var headerrightmerge = worksheet.Range("J3:L3");
				headerrightmerge.Merge();
				var headerrightmerge2 = worksheet.Range("J4:L4");
				headerrightmerge2.Merge();
				var headerrightmerge3 = worksheet.Range("J5:L5");
				headerrightmerge3.Merge();
				var headerrightmerge4 = worksheet.Range("J6:L6");
				headerrightmerge4.Merge();

				var headerrightmerge5 = worksheet.Range("M3:R3");
				headerrightmerge5.Merge();
				var headerrightmerge6 = worksheet.Range("M4:R4");
				headerrightmerge6.Merge();
				var headerrightmerge7 = worksheet.Range("M5:N5");
				headerrightmerge7.Merge();
				var headerrightmerge8 = worksheet.Range("P5:Q5");
				headerrightmerge8.Merge();
				var headerrightmerge9 = worksheet.Range("M6:N6");
				headerrightmerge9.Merge();
				var headerrightmerge10 = worksheet.Range("O6:Q6");
				headerrightmerge10.Merge();

				//merge cells for service type header
				var servicetypemerge = worksheet.Range("A8:E8");
				servicetypemerge.Merge();
				var servicetypemerge2 = worksheet.Range("F8:J8");
				servicetypemerge2.Merge();
				var servicetypemerge3 = worksheet.Range("K8:L8");
				servicetypemerge3.Merge();
				var servicetypemerge4 = worksheet.Range("M8:P8");
				servicetypemerge4.Merge();
				var servicetypemerge5 = worksheet.Range("Q8:R8");
				servicetypemerge5.Merge();
				var servicetypemerge6 = worksheet.Range("A9:B9");
				servicetypemerge6.Merge();
				var servicetypemerge7 = worksheet.Range("D9:E9");
				servicetypemerge7.Merge();
				var servicetypemerge8 = worksheet.Range("G9:I9");
				servicetypemerge8.Merge();
				var servicetypemerge9 = worksheet.Range("K9:L9");
				servicetypemerge9.Merge();
				var servicetypemerge10 = worksheet.Range("M9:P9");
				servicetypemerge10.Merge();
				var servicetypemerge11 = worksheet.Range("A10:B10");
				servicetypemerge11.Merge();
				var servicetypemerge12 = worksheet.Range("D10:F10");
				servicetypemerge12.Merge();
				var servicetypemerge13 = worksheet.Range("K10:L10");
				servicetypemerge13.Merge();
				var servicetypemerge14 = worksheet.Range("A11:D11");
				servicetypemerge14.Merge();
				var servicetypemerge15 = worksheet.Range("E11:R11");
				servicetypemerge15.Merge();

				//merge cells for time section
				var timemerge = worksheet.Range("A13:B13");
				timemerge.Merge();
				var timemerge2 = worksheet.Range("A14:B14");
				timemerge2.Merge();
				var timemerge3 = worksheet.Range("A15:B15");
				timemerge3.Merge();
				var timemerge4 = worksheet.Range("A16:B16");
				timemerge4.Merge();
				var timemerge5 = worksheet.Range("A17:B17");
				timemerge5.Merge();
				var timemerge6 = worksheet.Range("A18:B18");
				timemerge6.Merge();
				var timemerge7 = worksheet.Range("A19:B19");
				timemerge7.Merge();
				var timemerge8 = worksheet.Range("L18:Q18");
				timemerge8.Merge();
				var timemerge9 = worksheet.Range("L20:Q20");
				timemerge9.Merge();

				//merge cells for order section
				var ordermerge = worksheet.Range("A22:R22");
				ordermerge.Merge();
				var ordermerge2 = worksheet.Range("A23:R23");
				ordermerge2.Merge();
				var ordermerge3 = worksheet.Range("A24:R24");
				ordermerge3.Merge();

				//merge cells for work section
				var workmerge = worksheet.Range("A26:R26");
				workmerge.Merge();
				var workmerge2 = worksheet.Range("A27:C27");
				workmerge2.Merge();
				var workmerge3 = worksheet.Range("A28:C28");
				workmerge3.Merge();
				var workmerge4 = worksheet.Range("A29:C29");
				workmerge4.Merge();
				var workmerge5 = worksheet.Range("A30:C30");
				workmerge5.Merge();
				var workmerge6 = worksheet.Range("A31:C31");
				workmerge6.Merge();
				var workmerge7 = worksheet.Range("A32:C32");
				workmerge7.Merge();
				var workmerge8 = worksheet.Range("A33:C33");
				workmerge8.Merge();
				var workmerge9 = worksheet.Range("A34:C34");
				workmerge9.Merge();
				var workmerge10 = worksheet.Range("A35:C35");
				workmerge10.Merge();
				var workmerge11 = worksheet.Range("A36:C36");
				workmerge11.Merge();
				var workmerge12 = worksheet.Range("A37:C37");
				workmerge12.Merge();
				var workmerge13 = worksheet.Range("A38:C38");
				workmerge13.Merge();
				var workmerge14 = worksheet.Range("A39:C39");
				workmerge14.Merge();

				var workmerge15 = worksheet.Range("D27:F27");
				workmerge15.Merge();
				var workmerge16 = worksheet.Range("D28:F28");
				workmerge16.Merge();
				var workmerge17 = worksheet.Range("D29:F29");
				workmerge17.Merge();
				var workmerge18 = worksheet.Range("D30:F30");
				workmerge18.Merge();
				var workmerge19 = worksheet.Range("D31:F31");
				workmerge19.Merge();
				var workmerge20 = worksheet.Range("D32:F32");
				workmerge20.Merge();
				var workmerge21 = worksheet.Range("D33:F33");
				workmerge21.Merge();
				var workmerge22 = worksheet.Range("D34:F34");
				workmerge22.Merge();
				var workmerge23 = worksheet.Range("D35:F35");
				workmerge23.Merge();
				var workmerge24 = worksheet.Range("D36:F36");
				workmerge24.Merge();
				var workmerge25 = worksheet.Range("D37:F37");
				workmerge25.Merge();
				var workmerge26 = worksheet.Range("D38:F38");
				workmerge26.Merge();
				var workmerge27 = worksheet.Range("D39:F39");
				workmerge27.Merge();
				var workmerge28 = worksheet.Range("G27:R27");
				workmerge28.Merge();
				var workmerge29 = worksheet.Range("G28:R28");
				workmerge29.Merge();
				var workmerge30 = worksheet.Range("G29:R29");
				workmerge30.Merge();
				var workmerge31 = worksheet.Range("G30:R30");
				workmerge31.Merge();
				var workmerge32 = worksheet.Range("G31:R31");
				workmerge32.Merge();
				var workmerge33 = worksheet.Range("G32:R32");
				workmerge33.Merge();
				var workmerge34 = worksheet.Range("G33:R33");
				workmerge34.Merge();
				var workmerge35 = worksheet.Range("G34:R34");
				workmerge35.Merge();
				var workmerge36 = worksheet.Range("G35:R35");
				workmerge36.Merge();
				var workmerge37 = worksheet.Range("G36:R36");
				workmerge37.Merge();
				var workmerge38 = worksheet.Range("G37:R37");
				workmerge38.Merge();
				var workmerge39 = worksheet.Range("G38:R38");
				workmerge39.Merge();


				worksheet.Cell("A1").Value = "Hello";
				worksheet.Cell("A2").Value = "World";

				// Add more lines
				worksheet.Cell("A3").Value = "This";
				worksheet.Cell("A4").Value = "is";
				worksheet.Cell("A5").Value = "ClosedXML";

				workbook.SaveAs(filePath);
			}
		}
	}
}
