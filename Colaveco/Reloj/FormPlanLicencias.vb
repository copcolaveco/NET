Public Class FormPlanLicencias
    Private _anio As Integer
#Region "Constructores"
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        TextAmarillo.BackColor = Color.Yellow
        TextNaranja.BackColor = Color.Orange
        TextRojo.BackColor = Color.Red
        calcularano()
        cargarUsuarios()
        cargarlista()
        cargarsinaprobar()
        ComboUsuarios.Items.Add("Todos")
        ComboUsuarios.Text = "Todos"
    End Sub
#End Region
    Private Sub cargarUsuarios()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboUsuarios.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Private Sub calcularano()
        Dim hoy As Date = Now
        Dim ano As Integer = 0
        ano = hoy.Year
        _anio = hoy.Year
        NumericAno.Value = ano
    End Sub
    Private Sub cargarlista()
        Dim l As New dLicencias
        Dim lista As New ArrayList
        Dim ano As Integer = 0
        ano = NumericAno.Value
        lista = l.listarxano(ano)
        Dim fila As Integer = 0
        Dim columna As Integer = 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim dia As Integer = 0
                Dim dia2 As Integer = 0
                Dim mes As Integer = 0
                Dim mes2 As Integer = 0
                DataGridView1.Rows.Clear()
                DataGridView1.Rows.Add(12)
                DataGridView1(0, 0).Value = "Enero"
                DataGridView1(0, 1).Value = "Febrero"
                DataGridView1(0, 2).Value = "Marzo"
                DataGridView1(0, 3).Value = "Abril"
                DataGridView1(0, 4).Value = "Mayo"
                DataGridView1(0, 5).Value = "Junio"
                DataGridView1(0, 6).Value = "Julio"
                DataGridView1(0, 7).Value = "Agosto"
                DataGridView1(0, 8).Value = "Setiembre"
                DataGridView1(0, 9).Value = "Octubre"
                DataGridView1(0, 10).Value = "Noviembre"
                DataGridView1(0, 11).Value = "Diciembre"
                Dim contador As String = ""
                For Each l In lista
                    dia = Microsoft.VisualBasic.DateAndTime.Day(l.DESDE)
                    dia2 = Microsoft.VisualBasic.DateAndTime.Day(l.HASTA)
                    mes = Microsoft.VisualBasic.DateAndTime.Month(l.DESDE)
                    mes2 = Microsoft.VisualBasic.DateAndTime.Month(l.HASTA)

                    If mes = 1 And mes2 = 1 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 0).Value = DataGridView1(i, 0).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 0).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 0).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 0).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 0).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 1 And mes2 = 2 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 0).Value = DataGridView1(i, 0).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 0).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 0).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 0).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 0).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 1).Value = DataGridView1(j, 1).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 1).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 1).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 1).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 1).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 2 And mes2 = 2 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 1).Value = DataGridView1(i, 1).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 1).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 1).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 1).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 1).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 2 And mes2 = 3 Then
                        For i = dia To 28
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 1).Value = DataGridView1(i, 1).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 1).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 1).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 1).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 1).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 2).Value = DataGridView1(j, 2).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 2).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 2).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 2).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 2).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 3 And mes2 = 3 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 2).Value = DataGridView1(i, 2).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 2).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 2).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 2).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 2).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 3 And mes2 = 4 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 2).Value = DataGridView1(i, 2).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 2).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 2).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 2).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 2).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 3).Value = DataGridView1(j, 3).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 3).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 3).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 3).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 3).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 4 And mes2 = 4 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 3).Value = DataGridView1(i, 3).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 3).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 3).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 3).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 3).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 4 And mes2 = 5 Then
                        For i = dia To 30
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 3).Value = DataGridView1(i, 3).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 3).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 3).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 3).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 3).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 4).Value = DataGridView1(j, 4).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 4).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 4).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 4).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 4).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 5 And mes2 = 5 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 4).Value = DataGridView1(i, 4).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 4).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 4).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 4).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 4).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 5 And mes2 = 6 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 4).Value = DataGridView1(i, 4).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 4).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 4).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 4).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 4).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 5).Value = DataGridView1(j, 5).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 5).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 5).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 5).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 5).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 6 And mes2 = 6 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 5).Value = DataGridView1(i, 5).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 5).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 5).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 5).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 5).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 6 And mes2 = 7 Then
                        For i = dia To 30
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 5).Value = DataGridView1(i, 5).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 5).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 5).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 5).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 5).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 6).Value = DataGridView1(j, 6).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 6).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 6).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 6).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 6).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 7 And mes2 = 7 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 6).Value = DataGridView1(i, 6).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 6).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 6).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 6).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 6).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 7 And mes2 = 8 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 6).Value = DataGridView1(i, 6).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 6).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 6).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 6).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 6).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 7).Value = DataGridView1(j, 7).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 7).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 7).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 7).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 7).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 8 And mes2 = 8 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 7).Value = DataGridView1(i, 7).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 7).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 7).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 7).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 7).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 8 And mes2 = 9 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 7).Value = DataGridView1(i, 7).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 7).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 7).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 7).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 7).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 8).Value = DataGridView1(j, 8).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 8).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 8).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 8).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 8).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 9 And mes2 = 9 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 8).Value = DataGridView1(i, 8).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 8).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 8).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 8).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 8).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 9 And mes2 = 10 Then
                        For i = dia To 30
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 8).Value = DataGridView1(i, 8).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 8).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 8).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 8).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 8).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 9).Value = DataGridView1(j, 9).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 9).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 9).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 9).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 9).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 10 And mes2 = 10 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 9).Value = DataGridView1(i, 9).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 9).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 9).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 9).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 9).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 10 And mes2 = 11 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 9).Value = DataGridView1(i, 9).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 9).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 9).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 9).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 9).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 10).Value = DataGridView1(j, 10).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 10).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 10).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 10).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 10).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 11 And mes2 = 11 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 10).Value = DataGridView1(i, 10).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 10).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 10).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 10).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 10).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 11 And mes2 = 12 Then
                        For i = dia To 30
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 10).Value = DataGridView1(i, 10).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 10).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 10).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 10).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 10).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 11).Value = DataGridView1(j, 11).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 11).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 11).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 11).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 11).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 12 And mes2 = 12 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 11).Value = DataGridView1(i, 11).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 11).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 11).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 11).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 11).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 12 And mes2 = 1 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 11).Value = DataGridView1(i, 11).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 11).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 11).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 11).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 11).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        'For j = 1 To dia2
                        '    contador = ""
                        '    Dim u As New dUsuario
                        '    u.ID = l.IDUSUARIO
                        '    u = u.buscar
                        '    DataGridView1(j, 11).Value = DataGridView1(j, 11).Value & u.USUARIO & "-"
                        '    contador = DataGridView1(j, 11).Value
                        '    If contador.Length > 4 Then
                        '        DataGridView1(j, 11).Style.BackColor = Color.Orange
                        '    ElseIf contador.Length > 7 Then
                        '        DataGridView1(j, 11).Style.BackColor = Color.Red
                        '    Else
                        '        DataGridView1(j, 11).Style.BackColor = Color.Yellow
                        '    End If
                        'Next j
                    End If



                    columna = 1

                Next
            End If
        End If
    End Sub
    Private Sub cargarsinaprobar()
        Dim l As New dLicencias
        Dim lista As New ArrayList
        Dim ano As Integer = 0
        ano = NumericAno.Value
        lista = l.listar
        Dim texto As String = ""
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each l In lista
                    If l.APROBADA = 0 Then
                        Dim u As New dUsuario
                        u.ID = l.IDUSUARIO
                        u = u.buscar
                        texto = texto & u.NOMBRE & " " & l.DESDE & " - " & l.HASTA & " / "
                        u = Nothing
                    End If
                Next
            End If
        End If
        If texto <> "" Then
            TextSinAprobar.Text = texto
        End If
    End Sub
    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        If ComboUsuarios.Text = "Todos" Then
            DataGridView1.Rows.Clear()
            cargarlista()
        Else
            DataGridView1.Rows.Clear()
            cargarxusuario()
        End If
    End Sub
    Private Sub cargarxusuario()
        Dim usuario As dUsuario = CType(ComboUsuarios.SelectedItem, dUsuario)
        Dim idusuario As Integer = 0
        idusuario = usuario.ID
        Dim l As New dLicencias
        Dim lista As New ArrayList
        Dim ano As Integer = 0
        ano = NumericAno.Value
        lista = l.listarxusuario(idusuario, ano)
        Dim fila As Integer = 0
        Dim columna As Integer = 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim dia As Integer = 0
                Dim dia2 As Integer = 0
                Dim mes As Integer = 0
                Dim mes2 As Integer = 0
                DataGridView1.Rows.Clear()
                DataGridView1.Rows.Add(12)
                DataGridView1(0, 0).Value = "Enero"
                DataGridView1(0, 1).Value = "Febrero"
                DataGridView1(0, 2).Value = "Marzo"
                DataGridView1(0, 3).Value = "Abril"
                DataGridView1(0, 4).Value = "Mayo"
                DataGridView1(0, 5).Value = "Junio"
                DataGridView1(0, 6).Value = "Julio"
                DataGridView1(0, 7).Value = "Agosto"
                DataGridView1(0, 8).Value = "Setiembre"
                DataGridView1(0, 9).Value = "Octubre"
                DataGridView1(0, 10).Value = "Noviembre"
                DataGridView1(0, 11).Value = "Diciembre"
                Dim contador As String = ""
                For Each l In lista
                    dia = Microsoft.VisualBasic.DateAndTime.Day(l.DESDE)
                    dia2 = Microsoft.VisualBasic.DateAndTime.Day(l.HASTA)
                    mes = Microsoft.VisualBasic.DateAndTime.Month(l.DESDE)
                    mes2 = Microsoft.VisualBasic.DateAndTime.Month(l.HASTA)

                    If mes = 1 And mes2 = 1 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 0).Value = DataGridView1(i, 0).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 0).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 0).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 0).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 0).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 1 And mes2 = 2 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 0).Value = DataGridView1(i, 0).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 0).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 0).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 0).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 0).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 1).Value = DataGridView1(j, 1).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 1).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 1).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 1).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 1).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 2 And mes2 = 2 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 1).Value = DataGridView1(i, 1).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 1).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 1).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 1).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 1).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 2 And mes2 = 3 Then
                        For i = dia To 28
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 1).Value = DataGridView1(i, 1).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 1).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 1).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 1).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 1).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 2).Value = DataGridView1(j, 2).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 2).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 2).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 2).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 2).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 3 And mes2 = 3 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 2).Value = DataGridView1(i, 2).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 2).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 2).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 2).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 2).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 3 And mes2 = 4 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 2).Value = DataGridView1(i, 2).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 2).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 2).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 2).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 2).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 3).Value = DataGridView1(j, 3).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 3).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 3).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 3).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 3).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 4 And mes2 = 4 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 3).Value = DataGridView1(i, 3).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 3).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 3).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 3).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 3).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 4 And mes2 = 5 Then
                        For i = dia To 30
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 3).Value = DataGridView1(i, 3).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 3).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 3).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 3).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 3).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 4).Value = DataGridView1(j, 4).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 4).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 4).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 4).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 4).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 5 And mes2 = 5 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 4).Value = DataGridView1(i, 4).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 4).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 4).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 4).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 4).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 5 And mes2 = 6 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 4).Value = DataGridView1(i, 4).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 4).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 4).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 4).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 4).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 5).Value = DataGridView1(j, 5).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 5).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 5).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 5).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 5).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 6 And mes2 = 6 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 5).Value = DataGridView1(i, 5).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 5).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 5).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 5).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 5).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 6 And mes2 = 7 Then
                        For i = dia To 30
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 5).Value = DataGridView1(i, 5).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 5).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 5).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 5).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 5).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 6).Value = DataGridView1(j, 6).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 6).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 6).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 6).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 6).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 7 And mes2 = 7 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 6).Value = DataGridView1(i, 6).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 6).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 6).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 6).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 6).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 7 And mes2 = 8 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 6).Value = DataGridView1(i, 6).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 6).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 6).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 6).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 6).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 7).Value = DataGridView1(j, 7).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 7).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 7).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 7).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 7).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 8 And mes2 = 8 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 7).Value = DataGridView1(i, 7).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 7).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 7).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 7).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 7).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 8 And mes2 = 9 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 7).Value = DataGridView1(i, 7).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 7).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 7).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 7).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 7).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 8).Value = DataGridView1(j, 8).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 8).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 8).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 8).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 8).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 9 And mes2 = 9 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 8).Value = DataGridView1(i, 8).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 8).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 8).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 8).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 8).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 9 And mes2 = 10 Then
                        For i = dia To 30
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 8).Value = DataGridView1(i, 8).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 8).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 8).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 8).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 8).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 9).Value = DataGridView1(j, 9).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 9).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 9).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 9).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 9).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 10 And mes2 = 10 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 9).Value = DataGridView1(i, 9).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 9).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 9).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 9).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 9).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 10 And mes2 = 11 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 9).Value = DataGridView1(i, 9).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 9).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 9).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 9).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 9).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 10).Value = DataGridView1(j, 10).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 10).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 10).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 10).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 10).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 11 And mes2 = 11 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 10).Value = DataGridView1(i, 10).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 10).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 10).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 10).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 10).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 11 And mes2 = 12 Then
                        For i = dia To 30
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 10).Value = DataGridView1(i, 10).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 10).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 10).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 10).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 10).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        For j = 1 To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(j, 11).Value = DataGridView1(j, 11).Value & u.USUARIO & "-"
                            contador = DataGridView1(j, 11).Value
                            If contador.Length > 7 Then
                                DataGridView1(j, 11).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(j, 11).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(j, 11).Style.BackColor = Color.Yellow
                            End If
                        Next j
                    End If
                    If mes = 12 And mes2 = 12 Then
                        For i = dia To dia2
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 11).Value = DataGridView1(i, 11).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 11).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 11).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 11).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 11).Style.BackColor = Color.Yellow
                            End If
                        Next i
                    ElseIf mes = 12 And mes2 = 1 Then
                        For i = dia To 31
                            contador = ""
                            Dim u As New dUsuario
                            u.ID = l.IDUSUARIO
                            u = u.buscar
                            DataGridView1(i, 11).Value = DataGridView1(i, 11).Value & u.USUARIO & "-"
                            contador = DataGridView1(i, 11).Value
                            If contador.Length > 7 Then
                                DataGridView1(i, 11).Style.BackColor = Color.Red
                            ElseIf contador.Length > 4 Then
                                DataGridView1(i, 11).Style.BackColor = Color.Orange
                            Else
                                DataGridView1(i, 11).Style.BackColor = Color.Yellow
                            End If
                        Next i
                        'For j = 1 To dia2
                        '    contador = ""
                        '    Dim u As New dUsuario
                        '    u.ID = l.IDUSUARIO
                        '    u = u.buscar
                        '    DataGridView1(j, 11).Value = DataGridView1(j, 11).Value & u.USUARIO & "-"
                        '    contador = DataGridView1(j, 11).Value
                        '    If contador.Length > 4 Then
                        '        DataGridView1(j, 11).Style.BackColor = Color.Orange
                        '    ElseIf contador.Length > 7 Then
                        '        DataGridView1(j, 11).Style.BackColor = Color.Red
                        '    Else
                        '        DataGridView1(j, 11).Style.BackColor = Color.Yellow
                        '    End If
                        'Next j
                    End If



                    columna = 1

                Next
            End If
        End If
    End Sub
End Class