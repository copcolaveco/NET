Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormInformeRCRB

    Private Sub ButtonEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEmpresa.Click
        Dim v As New FormBuscarEmpresa
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim pro As dCliente = v.Cliente
            TextIdEmpresa.Text = pro.ID
            TextEmpresa.Text = pro.NOMBRE
        End If
    End Sub
    Private Sub listarempresa()
        DataGridView1.Rows.Clear()
        If TextIdEmpresa.Text.Trim.Length = 0 Then MsgBox("Debe seleccionar una empresa", MsgBoxStyle.Exclamation, "Atención") : TextIdEmpresa.Focus() : Exit Sub
        Dim s As New dSolicitudAnalisis
        Dim listafichas As New ArrayList
        Dim idempresa As Long = TextIdEmpresa.Text.Trim
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        listafichas = s.listarporfechacalidadempresa(fecdesde, fechasta, idempresa)

        Dim valor As Double = 0
        Dim valor1 As Double = 0
        ProgressBar1.Value = 0

        Dim idficha As Long = 0
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        If Not listafichas Is Nothing Then
            If listafichas.Count > 0 Then
                Dim csm As New dCalidadSolicitudMuestra
                Dim listacsm As New ArrayList
                For Each s In listafichas
                    idficha = s.ID
                    listacsm = csm.listarporsolicitud(idficha)
                    If Not listacsm Is Nothing Then
                        If listacsm.Count > 0 Then
                            DataGridView1.Rows.Add(listacsm.Count)
                            For Each csm In listacsm

                                Dim c As New dCalidad
                                Dim ibc As New dIbc
                                ibc.FICHA = idficha
                                ibc.MUESTRA = Trim(csm.MUESTRA)
                                ibc = ibc.buscarxfichaxmuestra
                                c.FICHA = idficha
                                c.MUESTRA = Trim(csm.MUESTRA)
                                c = c.buscarxfichaxmuestra

                                If Not c Is Nothing Then

                                    DataGridView1(columna, fila).Value = c.FICHA
                                    columna = columna + 1
                                    DataGridView1(columna, fila).Value = c.FECHA
                                    columna = columna + 1
                                    If c.MUESTRA <> "" Then
                                        DataGridView1(columna, fila).Value = c.MUESTRA
                                        columna = columna + 1
                                    Else
                                        DataGridView1(columna, fila).Value = ""
                                        columna = columna + 1
                                    End If
                                    If c.RC <> -1 And c.RC <> 0 Then
                                        DataGridView1(columna, fila).Value = c.RC
                                        If c.RC >= 600 Then
                                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                                        End If
                                        columna = columna + 1
                                    Else
                                        DataGridView1(columna, fila).Value = ""
                                        columna = columna + 1
                                    End If


                                    If Not ibc Is Nothing Then

                                        If ibc.RB <> -1 Or ibc.RB <> 0 Then
                                            DataGridView1(columna, fila).Value = ibc.RB
                                            columna = 0
                                            fila = fila + 1
                                        Else
                                            DataGridView1(columna, fila).Value = ""
                                            columna = 0
                                            fila = fila + 1
                                        End If
                                    Else
                                        DataGridView1(columna, fila).Value = ""
                                        columna = 0
                                        fila = fila + 1
                                    End If

                                End If
                            Next

                        End If

                    End If
                    valor = 100 / listafichas.Count
                    valor1 = valor1 + valor
                    If valor1 < 100 Then
                        ProgressBar1.Value = valor1
                    End If
                Next
            End If
        End If

    End Sub
    Private Sub ListarEmpresaExcel()
        If TextIdEmpresa.Text.Trim.Length = 0 Then MsgBox("Debe seleccionar una empresa", MsgBoxStyle.Exclamation, "Atención") : TextIdEmpresa.Focus() : Exit Sub
        Dim s As New dSolicitudAnalisis
        Dim listafichas As New ArrayList
        Dim idempresa As Long = TextIdEmpresa.Text.Trim
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        listafichas = s.listarporfechacalidadempresa(fecdesde, fechasta, idempresa)

        Dim valor As Double = 0
        Dim valor1 As Double = 0
        ProgressBar1.Value = 0

        Dim idficha As Long = 0

        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(2)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 10
        x1hoja.Cells(1, 3).columnwidth = 10
        x1hoja.Cells(1, 4).columnwidth = 8
        x1hoja.Cells(1, 5).columnwidth = 8
      

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "Informe de RC -  RB por empresa - " & fecdesde & " / " & fechasta
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = TextEmpresa.Text
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "Ficha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Fecha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Matrícula"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "RC"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "RB"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        columna = 1


        If Not listafichas Is Nothing Then
            If listafichas.Count > 0 Then
                Dim csm As New dCalidadSolicitudMuestra
                Dim listacsm As New ArrayList
                For Each s In listafichas
                    idficha = s.ID
                    listacsm = csm.listarporsolicitud(idficha)
                    If Not listacsm Is Nothing Then
                        If listacsm.Count > 0 Then
                            For Each csm In listacsm
                                Dim c As New dCalidad
                                Dim ibc As New dIbc
                                ibc.FICHA = idficha
                                ibc.MUESTRA = Trim(csm.MUESTRA)
                                ibc = ibc.buscarxfichaxmuestra
                                c.FICHA = idficha
                                c.MUESTRA = Trim(csm.MUESTRA)
                                c = c.buscarxfichaxmuestra

                                If Not c Is Nothing Then

                                    x1hoja.Cells(fila, columna).formula = c.FICHA
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    columna = columna + 1
                                    x1hoja.Cells(fila, columna).formula = c.FECHA
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    columna = columna + 1
                                    If c.MUESTRA <> "" Then
                                        x1hoja.Cells(fila, columna).formula = c.MUESTRA
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.RC <> -1 And c.RC <> 0 Then
                                        x1hoja.Cells(fila, columna).formula = c.RC
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        If c.RC >= 600 Then
                                            x1hoja.Cells(fila, columna).interior.color = RGB(255, 255, 0)
                                        End If
                                        columna = columna + 1
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If


                                    If Not ibc Is Nothing Then

                                        If ibc.RB <> -1 Or ibc.RB <> 0 Then
                                            x1hoja.Cells(fila, columna).formula = ibc.RB
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = 1
                                            fila = fila + 1

                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = 1
                                            fila = fila + 1

                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = 1
                                        fila = fila + 1
                                    End If

                                End If
                            Next

                        End If

                    End If
                    valor = 100 / listafichas.Count
                    valor1 = valor1 + valor
                    If valor1 < 100 Then
                        ProgressBar1.Value = valor1
                    End If
                Next


            End If
            x1app.Visible = True
            'x1libro.PrintPreview()

            x1app = Nothing
            x1libro = Nothing
            x1hoja = Nothing
        End If

    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        listarempresa()
    End Sub

    Private Sub ButtonExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcel.Click
        ListarEmpresaExcel()
    End Sub
End Class