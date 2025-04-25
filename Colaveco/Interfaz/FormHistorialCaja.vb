Public Class FormHistorialCaja
    Private _usuario As dUsuario

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarComboCajas()
        Usuario = u
    End Sub
#End Region
    Public Sub cargarComboCajas()
        Dim c As New dCajas
        Dim lista As New ArrayList
        lista = c.listar2
        ComboCajas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ComboCajas.Items.Add(c)
                Next
            End If
        End If
    End Sub
    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        listar()
    End Sub
    Private Sub listar()
        If ComboCajas.Text.Length > 0 Then
            'Dim idcaja As String = TextCaja.Text.Trim
            Dim idcaja As String = ComboCajas.Text.Trim
            Dim ec As New dEnvioCajas
            Dim p As New dCliente
            Dim lista As New ArrayList
            Dim fila As Integer = 0
            Dim columna As Integer = 0

            If entradaManual.Checked = True Then
                lista = ec.listarCajasEntradaManual(idcaja)
            Else
                lista = ec.listarxcajatodos(idcaja)
            End If

            DataGridView1.Rows.Clear()
            If Not lista Is Nothing Then
                DataGridView1.ColumnCount = 8
                DataGridView1.Rows.Add(lista.Count)
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each ec In lista
                            p.ID = ec.IDPRODUCTOR
                            p = p.buscar
                            If Not p Is Nothing Then
                                DataGridView1(columna, fila).Value = p.NOMBRE
                                columna = columna + 1
                            Else
                                DataGridView1(columna, fila).Value = ""
                                columna = columna + 1
                            End If
                            DataGridView1(columna, fila).Value = ec.IDCAJA
                            columna = columna + 1
                            DataGridView1(columna, fila).Value = ec.FECHAENVIO
                            columna = columna + 1
                            DataGridView1(columna, fila).Value = ec.OBSERVACIONES
                            columna = columna + 1
                            If ec.RECIBIDO = 1 Then
                                DataGridView1(columna, fila).Value = "Si"
                                columna = columna + 1
                            Else
                                DataGridView1(columna, fila).Value = "No"
                                columna = columna + 1
                            End If
                            DataGridView1(columna, fila).Value = ec.FECHARECIBO
                            columna = columna + 1
                            DataGridView1(columna, fila).Value = ec.OBSRECIBO
                            columna = columna + 1

                            If ec.OBSRECIBO.Trim = "Entrada manual" Then

                                Dim usuario As dUsuario = New dUsuario
                                usuario.ID = ec.CLIENTE
                                usuario = usuario.buscar()

                                If ec.CLIENTE <> 0 Then
                                    If Not usuario Is Nothing Then
                                        DataGridView1(columna, fila).Value = usuario.NOMBRE
                                    Else
                                        DataGridView1(columna, fila).Value = "Sin registro"
                                    End If
                                Else
                                    DataGridView1(columna, fila).Value = "Sin registro"
                                End If
                                columna = columna + 1
                            End If

                            columna = 0
                            fila = fila + 1
                        Next
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No hay datos para exportar.", MsgBoxStyle.Exclamation, "Exportar a Excel")
            Exit Sub
        End If

        Dim excelApp As New Microsoft.Office.Interop.Excel.Application
        Dim excelWorkbook As Microsoft.Office.Interop.Excel.Workbook = excelApp.Workbooks.Add()
        Dim excelWorksheet As Microsoft.Office.Interop.Excel.Worksheet = CType(excelWorkbook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        ' Encabezados
        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            excelWorksheet.Cells(1, i + 1) = DataGridView1.Columns(i).HeaderText
        Next

        ' Celdas
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            For j As Integer = 0 To DataGridView1.Columns.Count - 1
                If DataGridView1.Rows(i).Cells(j).Value IsNot Nothing Then
                    excelWorksheet.Cells(i + 2, j + 1) = DataGridView1.Rows(i).Cells(j).Value.ToString()
                End If
            Next
        Next

        ' Guardar archivo
        Dim ruta As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Reporte_" & Now.ToString("yyyyMMdd_HHmmss") & ".xls"
        excelWorkbook.SaveAs(ruta)
        excelWorkbook.Close()
        excelApp.Quit()

        releaseObject(excelWorksheet)
        releaseObject(excelWorkbook)
        releaseObject(excelApp)

        MsgBox("Reporte generado en: " & ruta, MsgBoxStyle.Information, "Exportación a Excel")
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub


End Class