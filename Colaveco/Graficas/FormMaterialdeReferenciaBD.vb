
Public Class FormMaterialdeReferenciaBD
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ComboItem.Text = "Células"
        ComboEquipo.Text = "Bentley"


    End Sub

#End Region
    Private Sub ButtonGraficar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGraficar.Click
        Chart1.Titles.Clear()

        Dim mr As New dMaterialReferencia
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecd As String
        Dim fech As String
        fecd = Format(fechadesde, "yyyy-MM-dd")
        fech = Format(fechahasta, "yyyy-MM-dd")
        Dim item As String = ComboItem.Text
        Dim equipo As String = ComboEquipo.Text
        Dim itemx As String = ""

        Dim lista As New ArrayList
        Dim lista2 As New ArrayList

        If item = "Células" Then
            itemx = "celulas"
            Chart1.Titles.Add("Nº de células x 1000/ml")
        ElseIf item = "Grasa" Then
            itemx = "grasa"
            Chart1.Titles.Add("Grasa")
        ElseIf item = "Proteína" Then
            itemx = "proteina"
            Chart1.Titles.Add("Proteína")
        ElseIf item = "Lactosa" Then
            itemx = "lactosa"
            Chart1.Titles.Add("Lactosa")
        ElseIf item = "Sólidos totales" Then
            itemx = "st"
            Chart1.Titles.Add("Sólidos totales")
        ElseIf item = "Crioscopía" Then
            itemx = "crioscopia"
            Chart1.Titles.Add("Crioscopía")
        ElseIf item = "Urea" Then
            itemx = "urea"
            Chart1.Titles.Add("Urea")
        ElseIf item = "Proteína verdadera" Then
            itemx = "proteinav"
            Chart1.Titles.Add("Proteína verdadera")
        ElseIf item = "Caseína" Then
            itemx = "caseina"
            Chart1.Titles.Add("Caseína")
        ElseIf item = "Densidad" Then
            itemx = "densidad"
            Chart1.Titles.Add("Densidad")
        ElseIf item = "pH" Then
            itemx = "ph"
            Chart1.Titles.Add("pH")
        ElseIf item = "Citratos" Then
            itemx = "citratos"
            Chart1.Titles.Add("Citratos")
        End If


        lista = mr.listarxitem(fecd, fech, itemx, equipo)

        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()


        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim difmaxreal As Integer = 0
                For Each mr In lista
                    'If mr.DIFERENCIA < 1 Then
                    'mr.DIFERENCIA = mr.DIFERENCIA * -1
                    'End If
                    If mr.DIFERENCIA < 0 Then
                        difmaxreal = mr.DIFMAXPERMITIDA
                        difmaxreal = difmaxreal * -1
                    Else
                        difmaxreal = mr.DIFMAXPERMITIDA
                    End If
                    Chart1.Series(0).Points.AddXY(mr.FECHA, mr.DIFERENCIAREAL)
                    Chart1.Series(2).Points.AddXY(mr.FECHA, mr.DIFERENCIAREAL)

                    If item = "Células" Then
                        Chart1.Series(1).Points.AddXY(mr.FECHA, difmaxreal)
                    End If



                    'Chart1.Series(0).Label = "#VALY"
                    'Chart1.Series(0).Label = "Y = #VALY" + ControlChars.Lf + "X = #VALX"

                    'Chart1.ChartAreas(0).AxisY.StripLines.Add(New StripLine())




                Next
            End If
        End If

    End Sub


End Class