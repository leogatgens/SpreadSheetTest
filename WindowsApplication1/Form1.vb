Imports FarPoint.Win
Imports FarPoint.Win.Spread.CellType

Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarParametrosHoja()
        ShowData()
    End Sub

    Private Sub ConfigurarParametrosHoja()
        Me.FpSpread1.ActiveSheet.AutoCalculation = True
        Me.FpSpread1.AllowUserFormulas = True



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FpSpread1.ActiveSheet.RecalculateAll()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FpSpread1.ActiveSheet.Recalculate()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FarPoint.Win.Spread.Design.ExternalDialogs.CellTypeEditor(Me.FpSpread1, FarPoint.Win.Spread.Design.DesignerMain.CellTypeEnum.CurrencyCellType)
    End Sub
    ''' <summary>
    ''' When a Numeric cell has a formula and the result is !#Value the component is slower than before
    ''' </summary>
    Private Sub ShowData()
        Dim cellTypeNumeric As New NumberCellType


        FpSpread1.ActiveSheet.Cells(0, 1).CellType = cellTypeNumeric
        'set formula
        FpSpread1.ActiveSheet.Cells(0, 2).Formula = " a1 + b1"

        FpSpread1.ActiveSheet.Cells(0, 3).Formula = " a1 + b1"
        FpSpread1.ActiveSheet.Cells(0, 3).CellType = cellTypeNumeric 'Here is the problem  becuase the result  is on a numeric  cell
        'set values
        FpSpread1.ActiveSheet.Cells(0, 0).Text = "Hi string"
        FpSpread1.ActiveSheet.Cells(0, 1).Value = 132
    End Sub

End Class
