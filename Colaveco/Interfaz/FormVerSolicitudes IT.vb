Public Class FormVerSolicitudes_IT
    Private _usuario As dUsuario
    Dim estado As String = ""
    Dim estado_cambio As Integer = 0
    
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        limpiar()
        cargarlistapendientes()
        RadioPendientes.Checked = True
    End Sub
    Private Sub limpiar()
       
    End Sub
    Private Sub cargarlista()
        Dim s As New dSolicitudesIT
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = s.listar

        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                Dim prioridad As String = ""
                Dim estado As String = ""
                DataGridView1.Rows.Add(lista.Count)
                For Each s In lista

                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.DESCRIPCION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.OBSERVACIONES
                    columna = columna + 1
                    If s.AUTORIZADO = 1 Then
                        DataGridView1(columna, fila).Value = "Si"
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Green
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "No"
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Red
                        columna = columna + 1
                    End If
                    u.ID = s.SOLICITANTE
                    u = u.buscar
                    If Not u Is Nothing Then
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If s.PRIORIDAD = 1 Then
                        prioridad = "Baja"
                    ElseIf s.PRIORIDAD = 2 Then
                        prioridad = "Media"
                    Else
                        prioridad = "Alta"
                    End If
                    DataGridView1(columna, fila).Value = prioridad
                    columna = columna + 1
                    If s.ESTADO = 1 Then
                        estado = "Pendiente"
                    ElseIf s.ESTADO = 2 Then
                        estado = "En proceso"
                    Else
                        estado = "Finalizado"
                    End If
                    DataGridView1(columna, fila).Value = estado
                    If estado = "Pendiente" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Red
                    ElseIf estado = "En proceso" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Yellow
                    Else
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Green
                    End If
                    
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub

    Private Sub RadioTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioTodas.CheckedChanged
        cargar()
    End Sub
    Private Sub cargar()
        If RadioTodas.Checked = True Then
            cargarlista()
        ElseIf RadioPendientes.Checked = True Then
            cargarlistapendientes()
        ElseIf RadioProceso.Checked = True Then
            cargarlistaenproceso()
        Else
            cargarlistafinalizadas()
        End If
    End Sub
    Private Sub cargarlistapendientes()
        Dim s As New dSolicitudesIT
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = s.listarpendientes(dtpDesde.Value, dtpHasta.Value)

        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                Dim prioridad As String = ""

                DataGridView1.Rows.Add(lista.Count)
                For Each s In lista

                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.DESCRIPCION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.OBSERVACIONES
                    columna = columna + 1
                    If s.AUTORIZADO = 1 Then
                        DataGridView1(columna, fila).Value = "Si"
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Green
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "No"
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Red
                        columna = columna + 1
                    End If
                    u.ID = s.SOLICITANTE
                    u = u.buscar
                    If Not u Is Nothing Then
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If s.PRIORIDAD = 1 Then
                        prioridad = "Baja"
                    ElseIf s.PRIORIDAD = 2 Then
                        prioridad = "Media"
                    Else
                        prioridad = "Alta"
                    End If
                    DataGridView1(columna, fila).Value = prioridad
                    columna = columna + 1
                    If s.ESTADO = 1 Then
                        estado = "Pendiente"
                    ElseIf s.ESTADO = 2 Then
                        estado = "En proceso"
                    Else
                        estado = "Finalizado"
                    End If
                    DataGridView1(columna, fila).Value = estado
                    If estado = "Pendiente" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Red
                    ElseIf estado = "En proceso" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Yellow
                    Else
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Green
                    End If
                    
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub cargarlistafinalizadas()
        Dim s As New dSolicitudesIT
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = s.listarfinalizadas(dtpDesde.Value, dtpHasta.Value)

        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                Dim prioridad As String = ""
                Dim estado As String = ""
                DataGridView1.Rows.Add(lista.Count)
                For Each s In lista

                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.DESCRIPCION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.OBSERVACIONES
                    columna = columna + 1
                    If s.AUTORIZADO = 1 Then
                        DataGridView1(columna, fila).Value = "Si"
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Green
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "No"
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Red
                        columna = columna + 1
                    End If
                    u.ID = s.SOLICITANTE
                    u = u.buscar
                    If Not u Is Nothing Then
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If s.PRIORIDAD = 1 Then
                        prioridad = "Baja"
                    ElseIf s.PRIORIDAD = 2 Then
                        prioridad = "Media"
                    Else
                        prioridad = "Alta"
                    End If
                    DataGridView1(columna, fila).Value = prioridad
                    columna = columna + 1
                    If s.ESTADO = 1 Then
                        estado = "Pendiente"
                    ElseIf s.ESTADO = 2 Then
                        estado = "En proceso"
                    Else
                        estado = "Finalizado"
                    End If
                    DataGridView1(columna, fila).Value = estado
                    If estado = "Pendiente" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Red
                    ElseIf estado = "En proceso" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Yellow
                    Else
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Green
                    End If
                    
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub

    Private Sub cargarlistaenproceso()
        Dim s As New dSolicitudesIT
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = s.listarenproceso(dtpDesde.Value, dtpHasta.Value)

        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                Dim prioridad As String = ""
                Dim estado As String = ""
                DataGridView1.Rows.Add(lista.Count)
                For Each s In lista

                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.DESCRIPCION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.OBSERVACIONES
                    columna = columna + 1
                    If s.AUTORIZADO = 1 Then
                        DataGridView1(columna, fila).Value = "Si"
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Green
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "No"
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Red
                        columna = columna + 1
                    End If
                    u.ID = s.SOLICITANTE
                    u = u.buscar
                    If Not u Is Nothing Then
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If s.PRIORIDAD = 1 Then
                        prioridad = "Baja"
                    ElseIf s.PRIORIDAD = 2 Then
                        prioridad = "Media"
                    Else
                        prioridad = "Alta"
                    End If
                    DataGridView1(columna, fila).Value = prioridad
                    columna = columna + 1
                    If s.ESTADO = 1 Then
                        estado = "Pendiente"
                    ElseIf s.ESTADO = 2 Then
                        estado = "En proceso"
                    Else
                        estado = "Finalizado"
                    End If
                    DataGridView1(columna, fila).Value = estado
                    If estado = "Pendiente" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Red
                    ElseIf estado = "En proceso" Then
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Yellow
                    Else
                        DataGridView1.Item(columna, fila).Style.BackColor = Color.Green
                    End If
                    
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub

    Private Sub RadioFinalizadas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioFinalizadas.CheckedChanged
        cargar()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim id As Long = 0
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        Dim s As New dSolicitudesIT
        id = row.Cells("Id").Value
        s.ID = id
        If DataGridView1.Columns(e.ColumnIndex).Name = "Finalizada" Then
            s.marcar(Usuario)
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "cambiar" Then
            If estado = "Pendiente" Then
                estado_cambio = 1
            ElseIf estado = "Proceso" Then
                estado_cambio = 2
            ElseIf estado = "Finalizado" Then
                estado_cambio = 3
            End If
            Dim v As New FormEstadoSolicitudIT(id, estado_cambio)
            v.ShowDialog()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "AgregarObservaciones" Then
            Dim v As New FormObservacionesIT(id)
            v.ShowDialog()
        End If
        cargar()
    End Sub

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Private Sub RadioProceso_CheckedChanged(sender As Object, e As EventArgs) Handles RadioProceso.CheckedChanged
        cargar()
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

        ' Datos
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            For j As Integer = 0 To DataGridView1.Columns.Count - 1
                If DataGridView1.Rows(i).Cells(j).Value IsNot Nothing Then
                    excelWorksheet.Cells(i + 2, j + 1) = DataGridView1.Rows(i).Cells(j).Value.ToString()
                End If
            Next
        Next

        ' Guardar archivo
        Dim ruta As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\SolicitudesIT_" & Now.ToString("yyyyMMdd_HHmmss") & ".xls"
        excelWorkbook.SaveAs(ruta)
        excelWorkbook.Close()
        excelApp.Quit()

        releaseObject(excelWorksheet)
        releaseObject(excelWorkbook)
        releaseObject(excelApp)

        MsgBox("Archivo Excel generado correctamente en: " & ruta, MsgBoxStyle.Information, "Exportación exitosa")
    End Sub

End Class