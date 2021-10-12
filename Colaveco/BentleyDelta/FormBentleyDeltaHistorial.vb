Public Class FormBentleyDeltaHistorial
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ComboItem.Text = "Grasa"
    End Sub

#End Region
    Private Sub cargarlista()
        Dim p As New dBentleyDelta
        Dim lista As New ArrayList
        Dim c1 As Double = 0
        Dim c2 As Double = 0
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fechad As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechah As String = Format(fechahasta, "yyyy-MM-dd")
        lista = p.listarporfecha(fechad, fechah)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    DataGridView1(columna, fila).Value = p.CODIGO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.HORA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.EQUIPO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.GRASA
                    'If p.GRASA >= 0 Then
                    '    If p.GRASA <= 0.05 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Green
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    ElseIf p.GRASA > 0.05 And p.GRASA <= 0.08 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    '    ElseIf p.GRASA > 0.08 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Red
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    End If
                    'Else
                    '    If p.GRASA >= -0.05 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Green
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    ElseIf p.GRASA < -0.05 And p.GRASA >= -0.08 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    '    ElseIf p.GRASA < -0.08 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Red
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    End If
                    'End If
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = p.PROTEINA
                    'If p.PROTEINA >= 0 Then
                    '    If p.PROTEINA <= 0.05 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Green
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    ElseIf p.PROTEINA > 0.05 And p.PROTEINA <= 0.08 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    '    ElseIf p.PROTEINA > 0.08 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Red
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    End If
                    'Else
                    '    If p.PROTEINA >= -0.05 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Green
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    ElseIf p.PROTEINA < -0.05 And p.PROTEINA >= -0.08 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    '    ElseIf p.PROTEINA < -0.08 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Red
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    End If
                    'End If
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = p.LACTOSA
                    'If p.LACTOSA >= 0 Then
                    '    If p.LACTOSA <= 0.05 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Green
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    ElseIf p.LACTOSA > 0.05 And p.LACTOSA <= 0.08 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    '    ElseIf p.LACTOSA > 0.08 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Red
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    End If
                    'Else
                    '    If p.LACTOSA >= -0.05 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Green
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    ElseIf p.LACTOSA < -0.05 And p.LACTOSA >= -0.08 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    '    ElseIf p.LACTOSA < -0.08 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Red
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    End If
                    'End If
                    'columna = columna + 1

                    'DataGridView1(columna, fila).Value = p.SOLTOTALES
                    'If p.SOLTOTALES >= 0 Then
                    '    If p.SOLTOTALES <= 0.15 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Green
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    ElseIf p.SOLTOTALES > 0.15 And p.SOLTOTALES <= 0.25 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    '    ElseIf p.SOLTOTALES > 0.25 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Red
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    End If
                    'Else
                    '    If p.SOLTOTALES >= -0.15 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Green
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    ElseIf p.SOLTOTALES < -0.15 And p.SOLTOTALES >= -0.25 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    '    ElseIf p.SOLTOTALES < -0.25 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Red
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    End If
                    'End If
                    'columna = columna + 1

                    'DataGridView1(columna, fila).Value = p.CELULAS
                    'If p.CCELULAS >= "v" Then
                    '    DataGridView1(columna, fila).Style.BackColor = Color.Green
                    '    DataGridView1(columna, fila).Style.ForeColor = Color.White
                    'ElseIf p.CCELULAS = "a" Then
                    '    DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    'ElseIf p.CCELULAS = "r" Then
                    '    DataGridView1(columna, fila).Style.BackColor = Color.Red
                    '    DataGridView1(columna, fila).Style.ForeColor = Color.White
                    'End If
                    'columna = columna + 1

                    'If p.CRIOSCOPIA >= 0 Then
                    '    If p.CRIOSCOPIA <= 5 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Green
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    ElseIf p.CRIOSCOPIA > 5 And p.CRIOSCOPIA <= 10 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    '    ElseIf p.CRIOSCOPIA > 10 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Red
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    End If
                    'Else
                    '    If p.CRIOSCOPIA >= -5 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Green
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    ElseIf p.CRIOSCOPIA < -5 And p.CRIOSCOPIA >= -10 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    '    ElseIf p.CRIOSCOPIA < -10 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Red
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    End If
                    'End If
                    'If p.CR1 = 0 And p.CR2 = 0 Then
                    '    DataGridView1(columna, fila).Value = "no"
                    '    DataGridView1(columna, fila).Style.BackColor = Color.White
                    'Else
                    '    DataGridView1(columna, fila).Value = p.CRIOSCOPIA
                    'End If
                    'columna = columna + 1

                    'If p.UREA >= 0 Then
                    '    If p.UREA <= 4 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Green
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    ElseIf p.UREA > 4 And p.UREA <= 8 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    '    ElseIf p.UREA > 8 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Red
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    End If
                    'Else
                    '    If p.UREA >= -4 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Green
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    ElseIf p.UREA < -4 And p.UREA >= -8 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    '    ElseIf p.UREA < -8 Then
                    '        DataGridView1(columna, fila).Style.BackColor = Color.Red
                    '        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    '    End If
                    'End If
                    'If p.UR1 = 0 And p.UR2 = 0 Then
                    '    DataGridView1(columna, fila).Value = "no"
                    '    DataGridView1(columna, fila).Style.BackColor = Color.White
                    'Else
                    '    DataGridView1(columna, fila).Value = p.UREA
                    'End If
                    If p.GRASA >= 0 Then
                        If p.GRASA <= 0.05 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Green
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        ElseIf p.GRASA > 0.05 And p.GRASA <= 0.08 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        ElseIf p.GRASA > 0.08 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Red
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        End If
                    Else
                        If p.GRASA >= -0.05 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Green
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        ElseIf p.GRASA < -0.05 And p.GRASA >= -0.08 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        ElseIf p.GRASA < -0.08 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Red
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        End If
                    End If
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.PROTEINA
                    If p.PROTEINA >= 0 Then
                        If p.PROTEINA <= 0.05 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Green
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        ElseIf p.PROTEINA > 0.05 And p.PROTEINA <= 0.08 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        ElseIf p.PROTEINA > 0.08 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Red
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        End If
                    Else
                        If p.PROTEINA >= -0.05 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Green
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        ElseIf p.PROTEINA < -0.05 And p.PROTEINA >= -0.08 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        ElseIf p.PROTEINA < -0.08 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Red
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        End If
                    End If
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.LACTOSA
                    If p.LACTOSA >= 0 Then
                        If p.LACTOSA <= 0.05 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Green
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        ElseIf p.LACTOSA > 0.05 And p.LACTOSA <= 0.08 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        ElseIf p.LACTOSA > 0.08 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Red
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        End If
                    Else
                        If p.LACTOSA >= -0.05 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Green
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        ElseIf p.LACTOSA < -0.05 And p.LACTOSA >= -0.08 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        ElseIf p.LACTOSA < -0.08 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Red
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        End If
                    End If
                    columna = columna + 1

                    DataGridView1(columna, fila).Value = p.SOLTOTALES
                    If p.SOLTOTALES >= 0 Then
                        If p.SOLTOTALES <= 0.15 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Green
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        ElseIf p.SOLTOTALES > 0.15 And p.SOLTOTALES <= 0.25 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        ElseIf p.SOLTOTALES > 0.25 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Red
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        End If
                    Else
                        If p.SOLTOTALES >= -0.15 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Green
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        ElseIf p.SOLTOTALES < -0.15 And p.SOLTOTALES >= -0.25 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        ElseIf p.SOLTOTALES < -0.25 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Red
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        End If
                    End If
                    columna = columna + 1

                    DataGridView1(columna, fila).Value = p.CELULAS
                    c1 = p.MCE
                    c2 = (p.CELULAS / c1) * 100
                    If c2 < 0 Then
                        c2 = c2 * -1
                    End If
                    If c2 <= 5 Then
                        DataGridView1(columna, fila).Style.BackColor = Color.Green
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    ElseIf c2 > 5 And c2 <= 10 Then
                        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                    ElseIf c2 > 10 Then
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    End If
                    columna = columna + 1

                    If p.CRIOSCOPIA >= 0 Then
                        If p.CRIOSCOPIA <= 5 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Green
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        ElseIf p.CRIOSCOPIA > 5 And p.CRIOSCOPIA <= 10 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        ElseIf p.CRIOSCOPIA > 10 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Red
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        End If
                    Else
                        If p.CRIOSCOPIA >= -5 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Green
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        ElseIf p.CRIOSCOPIA < -5 And p.CRIOSCOPIA >= -10 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        ElseIf p.CRIOSCOPIA < -10 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Red
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        End If
                    End If
                    If p.CR1 = -1 And p.CR2 = -1 Then
                        DataGridView1(columna, fila).Value = "no"
                        DataGridView1(columna, fila).Style.BackColor = Color.White
                    Else
                        DataGridView1(columna, fila).Value = p.CRIOSCOPIA
                    End If
                    columna = columna + 1
                    If p.UREA >= 0 Then
                        If p.UREA <= 4 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Green
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        ElseIf p.UREA > 4 And p.UREA <= 8 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        ElseIf p.UREA > 8 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Red
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        End If
                    Else
                        If p.UREA >= -4 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Green
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        ElseIf p.UREA < -4 And p.UREA >= -8 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        ElseIf p.UREA < -8 Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Red
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        End If
                    End If
                    If p.UR1 = -1 And p.UR2 = -1 Then
                        DataGridView1(columna, fila).Value = "no"
                        DataGridView1(columna, fila).Style.BackColor = Color.White
                    Else
                        DataGridView1(columna, fila).Value = p.UREA
                    End If

                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        cargarlista()
        graficar1()
    End Sub
    Private Sub graficar1()
        Dim bd As New dBentleyDelta
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecd As String
        Dim fech As String
        fecd = Format(fechadesde, "yyyy-MM-dd")
        fech = Format(fechahasta, "yyyy-MM-dd")
        Dim item As String = ComboItem.Text
        Dim itemx As String = ""

        Chart1.Titles.Clear()

        Dim lista As New ArrayList
        Dim lista2 As New ArrayList

        If item = "Células" Then
            itemx = "celulas"
            Chart1.Titles.Add("Células - 5% (verde) / 10% (amarillo) / 15% (rojo)")
        ElseIf item = "Grasa" Then
            itemx = "grasa"
            Chart1.Titles.Add("Grasa - 0.05 (verde) / 0.08 (amarillo) / 0.11 (rojo)")
        ElseIf item = "Proteína" Then
            itemx = "proteina"
            Chart1.Titles.Add("Proteína - 0.05 (verde) / 0.08 (amarillo) / 0.11 (rojo)")
        ElseIf item = "Lactosa" Then
            itemx = "lactosa"
            Chart1.Titles.Add("Lactosa - - 0.05 (verde) / 0.08 (amarillo) / 0.11 (rojo)")
        ElseIf item = "Sólidos totales" Then
            itemx = "st"
            Chart1.Titles.Add("Sólidos totales - 0.15 (verde) / 0.25 (amarillo) / 0.33 (rojo)")
        ElseIf item = "Crioscopía" Then
            itemx = "crioscopia"
            Chart1.Titles.Add("Crioscopía - 5 (verde) / 10 (amarillo) / 15 (rojo)")
        ElseIf item = "Uréa" Then
            itemx = "urea"
            Chart1.Titles.Add("Uréa - 4 (verde) / 8 (amarillo) / 12 (rojo)")
        End If


        lista = bd.listarporfecha(fecd, fech)
       

        Chart1.Series(0).Points.Clear()


        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each bd In lista
                    If itemx = "grasa" Then
                        Chart1.Series(0).Points.AddXY(bd.FECHA, bd.GRASA)
                    ElseIf itemx = "proteina" Then
                        Chart1.Series(0).Points.AddXY(bd.FECHA, bd.PROTEINA)
                    ElseIf itemx = "lactosa" Then
                        Chart1.Series(0).Points.AddXY(bd.FECHA, bd.LACTOSA)
                    ElseIf itemx = "st" Then
                        Chart1.Series(0).Points.AddXY(bd.FECHA, bd.SOLTOTALES)
                    ElseIf itemx = "celulas" Then
                        Chart1.Series(0).Points.AddXY(bd.FECHA, bd.CELULAS)
                    ElseIf itemx = "crioscopia" Then
                        If bd.CR1 <> 0 And bd.CR2 <> 0 Then
                            Chart1.Series(0).Points.AddXY(bd.FECHA, bd.CRIOSCOPIA)
                        End If
                    ElseIf itemx = "urea" Then
                        If bd.UR1 <> 0 And bd.UR2 <> 0 Then
                            Chart1.Series(0).Points.AddXY(bd.FECHA, bd.UREA)
                        End If
                    End If
                    'Chart1.Series(0).Points.AddXY(bd.FECHA, bd.GRASA)
                Next
            End If
        End If
        bd = Nothing
        lista = Nothing
        lista2 = Nothing
    End Sub

    Private Sub ComboItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboItem.SelectedIndexChanged
        graficar1()
    End Sub
End Class