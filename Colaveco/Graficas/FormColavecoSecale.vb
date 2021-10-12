Public Class FormColavecoSecale
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        RadioGrasa.Checked = True
        DateDesde.Value = Now
        DateHasta.Value = Now


    End Sub

#End Region

    Private Sub ButtonGraficar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGraficar.Click
        Chart1.Titles.Clear()
        'Chart2.Titles.Clear()
        graficar1()
        'graficar2()
    End Sub
    Private Sub graficar1()
        Dim s As New dSecale
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecd As String
        Dim fech As String
        fecd = Format(fechadesde, "yyyy-MM-dd")
        fech = Format(fechahasta, "yyyy-MM-dd")
        Dim item As String = ""
        Dim itemx As String = ""

        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim listapetri As New ArrayList

        If RadioGrasa.Checked = True Then
            item = "Grasa"
            itemx = "grasa"
            lista = s.listarcolaveco(fecd, fech)
            lista2 = s.listarsecale(fecd, fech)
            Chart1.Series(0).Points.Clear()
            Chart1.Series(1).Points.Clear()
            Chart1.Series(2).Points.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each s In lista
                        If s.GRASA <> -1 Then
                            Chart1.Series(0).Points.AddXY(s.FECHA, s.GRASA)
                        End If
                    Next
            End If
        End If
        If Not lista2 Is Nothing Then
            If lista2.Count > 0 Then
                For Each s In lista2
                    If s.GRASA <> -1 Then
                        Chart1.Series(1).Points.AddXY(s.FECHA, s.GRASA)
                    End If
                Next
            End If
        End If
            Chart1.Titles.Add("Grasa")

        ElseIf RadioLactosa.Checked = True Then
        item = "Lactosa"
        itemx = "lactosa"
        lista = s.listarcolaveco(fecd, fech)
        lista2 = s.listarsecale(fecd, fech)
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    If s.LACTOSA <> -1 Then
                        Chart1.Series(0).Points.AddXY(s.FECHA, s.LACTOSA)
                    End If
                Next
            End If
        End If
        If Not lista2 Is Nothing Then
            If lista2.Count > 0 Then
                For Each s In lista2
                    If s.LACTOSA <> -1 Then
                        Chart1.Series(1).Points.AddXY(s.FECHA, s.LACTOSA)
                    End If
                Next
            End If
        End If
            Chart1.Titles.Add("Lactosa")

        ElseIf RadioProteina.Checked = True Then
        item = "Proteína"
        itemx = "proteina"
        lista = s.listarcolaveco(fecd, fech)
        lista2 = s.listarsecale(fecd, fech)
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    If s.PROTEINA <> -1 Then
                        Chart1.Series(0).Points.AddXY(s.FECHA, s.PROTEINA)
                    End If
                Next
            End If
        End If
        If Not lista2 Is Nothing Then
            If lista2.Count > 0 Then
                For Each s In lista2
                    If s.PROTEINA <> -1 Then
                        Chart1.Series(1).Points.AddXY(s.FECHA, s.PROTEINA)
                    End If
                Next
            End If
        End If
            Chart1.Titles.Add("Proteína")

        ElseIf RadioRB.Checked = True Then
        item = "RB"
        itemx = "rb"
        lista = s.listarcolaveco(fecd, fech)
        lista2 = s.listarsecale(fecd, fech)
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    If s.RB <> -1 Then
                        Chart1.Series(0).Points.AddXY(s.FECHA, s.RB)
                    End If
                Next
            End If
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    If s.RBPETRI <> -1 Then
                        Chart1.Series(2).Points.AddXY(s.FECHA, s.RBPETRI)
                    End If
                Next
            End If
        End If
        If Not lista2 Is Nothing Then
            If lista2.Count > 0 Then
                For Each s In lista2
                    If s.RB <> -1 Then
                        Chart1.Series(1).Points.AddXY(s.FECHA, s.RB)
                    End If
                Next
            End If
        End If
            Chart1.Titles.Add("Recuento bacteriano")

        ElseIf RadioRC.Checked = True Then
        item = "RC"
        itemx = "rc"
        lista = s.listarcolaveco(fecd, fech)
        lista2 = s.listarsecale(fecd, fech)
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    If s.RC <> -1 Then
                        Chart1.Series(0).Points.AddXY(s.FECHA, s.RC)
                    End If
                Next
            End If
        End If
        If Not lista2 Is Nothing Then
            If lista2.Count > 0 Then
                For Each s In lista2
                    If s.RC <> -1 Then
                        Chart1.Series(1).Points.AddXY(s.FECHA, s.RC)
                    End If
                Next
            End If
        End If
            Chart1.Titles.Add("Recuento celular")

        ElseIf RadioST.Checked = True Then
        item = "Sólidos totales"
        itemx = "st"
        lista = s.listarcolaveco(fecd, fech)
        lista2 = s.listarsecale(fecd, fech)
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    If s.ST <> -1 Then
                        Chart1.Series(0).Points.AddXY(s.FECHA, s.ST)
                    End If
                Next
            End If
        End If
        If Not lista2 Is Nothing Then
            If lista2.Count > 0 Then
                For Each s In lista2
                    If s.ST <> -1 Then
                        Chart1.Series(1).Points.AddXY(s.FECHA, s.ST)
                    End If
                Next
            End If
        End If
        End If

        s = Nothing
        lista = Nothing
        lista2 = Nothing
    End Sub


End Class