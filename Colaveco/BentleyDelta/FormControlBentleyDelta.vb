Public Class FormControlBentleyDelta
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarlista()
    End Sub
#End Region
    Private Sub cargarlista()
        Dim p As New dBentleyDelta
        Dim lista As New ArrayList
        Dim c1 As Double = 0
        Dim c2 As Double = 0
        lista = p.listarsinvalidar
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim v As New FormBentleyDeltaHistorial
        v.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Valido" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim bd As New dBentleyDelta
            id = row.Cells("Id").Value
            bd.CODIGO = id
            bd.validar()
            cargarlista()
        End If
    End Sub
End Class