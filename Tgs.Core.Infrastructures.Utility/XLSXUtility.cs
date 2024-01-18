using System.Collections.Generic;
using System.Resources;
using ClosedXML.Excel;

namespace Tgs.Core.Infrastructures.Utility;

public static class XLSXUtility
{
    public static XLWorkbook Export<T>(this IEnumerable<T>? models, string sheetName)
    {
        var workbook = new XLWorkbook();
        var sheet = workbook.Worksheets.Add(sheetName);
        var colIdx = 1;

        foreach (var item in typeof(T).GetProperties())
            sheet.Cell(1, colIdx++).Value = item.Name;

        if (models == null) return workbook;

        sheet.Cell("A2").InsertData(models);

        return workbook;
    }

    public static XLWorkbook ExportWithLocalization<T>(this IEnumerable<T>? models,
        string sheetName,
        ResourceManager resourceManager)
    {
        var workbook = new XLWorkbook();
        var sheet = workbook.Worksheets.Add(sheetName);
        var colIdx = 1;

        foreach (var item in typeof(T).GetProperties())
            sheet.Cell(1, colIdx++).Value = resourceManager.GetString(item.Name) ?? item.Name;

        if (models == null) return workbook;

        sheet.Cell("A2").InsertData(models);

        return workbook;
    }
}