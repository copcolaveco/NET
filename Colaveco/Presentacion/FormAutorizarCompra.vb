Option Explicit On
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Public Class FormAutorizarCompra
    Dim compraid As Long = 0
#Region "Atributos"
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        listarcompras()
        'limpiar()
    End Sub

#End Region
    Private Sub listarcompras()
        Dim c As New dCompras

        Dim lista As New ArrayList
        lista = c.listarsinautorizar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each c In lista
                    Dim lc As New dLineaCompra
                    lc.IDCOMPRA = c.ID
                    lc = lc.buscarxidcompra
                    If Not lc Is Nothing Then
                        DataGridView1(columna, fila).Value = c.ID
                        columna = columna + 1
                        Dim pro As New dProveedores
                        pro.ID = c.PROVEEDOR
                        pro = pro.buscar
                        If Not pro Is Nothing Then
                            DataGridView1(columna, fila).Value = pro.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                        DataGridView1(columna, fila).Value = c.FECHA
                        columna = 0
                        fila = fila + 1
                    End If

                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If DataGridView1.Columns(e.ColumnIndex).Name = "IdCompra" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCompras
            id = row.Cells("IdCompra").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextIdCompra.Text = id
                compraid = id
                DateFecha.Value = c.FECHA
                TextObservaciones.Text = c.OBSERVACIONES
                Dim r As New dUsuario
                r.ID = c.USUARIOCREADOR
                r = r.buscar
                If Not r Is Nothing Then
                    TextResponsable.Text = r.NOMBRE
                End If
                Dim p As New dProveedores
                p.ID = c.PROVEEDOR
                p = p.buscar
                If Not p Is Nothing Then
                    TextProveedor.Text = p.NOMBRE
                End If
            End If
            listarlineas()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Proveedor" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCompras
            id = row.Cells("IdCompra").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextIdCompra.Text = id
                compraid = id
                DateFecha.Value = c.FECHA
                TextObservaciones.Text = c.OBSERVACIONES
                Dim r As New dUsuario
                r.ID = c.USUARIOCREADOR
                r = r.buscar
                If Not r Is Nothing Then
                    TextResponsable.Text = r.NOMBRE
                End If
                Dim p As New dProveedores
                p.ID = c.PROVEEDOR
                p = p.buscar
                If Not p Is Nothing Then
                    TextProveedor.Text = p.NOMBRE
                End If
            End If
            listarlineas()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim c As New dCompras
            id = row.Cells("IdCompra").Value
            c.ID = id
            c = c.buscar()
            If Not c Is Nothing Then
                TextIdCompra.Text = id
                compraid = id
                DateFecha.Value = c.FECHA
                TextObservaciones.Text = c.OBSERVACIONES
                Dim r As New dUsuario
                r.ID = c.USUARIOCREADOR
                r = r.buscar
                If Not r Is Nothing Then
                    TextResponsable.Text = r.NOMBRE
                End If
                Dim p As New dProveedores
                p.ID = c.PROVEEDOR
                p = p.buscar
                If Not p Is Nothing Then
                    TextProveedor.Text = p.NOMBRE
                End If
            End If
            listarlineas()
        End If
    End Sub
    Private Sub listarlineas()
        Dim lc As New dLineaCompra
        Dim idcompra As Long = TextIdCompra.Text
        Dim lista As New ArrayList
        Dim subtotal As Double = 0
        lista = lc.listarxidcompra(idcompra)
        DataGridView2.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView2.Rows.Add(lista.Count)
                For Each lc In lista
                    DataGridView2(columna, fila).Value = lc.ID
                    columna = columna + 1
                    Dim pro As New dProductos
                    pro.ID = lc.PRODUCTO
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        DataGridView2(columna, fila).Value = pro.NOMBRE
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = pro.DETALLE
                        columna = columna + 1
                    End If
                    DataGridView2(columna, fila).Value = lc.PRECIOANT
                    columna = columna + 1
                    If lc.MONEDAANT = 0 Then
                        DataGridView2(columna, fila).Value = "$"
                        columna = columna + 1
                    ElseIf lc.MONEDAANT = 1 Then
                        DataGridView2(columna, fila).Value = "U$S"
                        columna = columna + 1
                    End If
                    DataGridView2(columna, fila).Value = lc.FECHAPRECIOANT
                    columna = columna + 1
                    DataGridView2(columna, fila).Value = lc.CANTIDAD
                    columna = columna + 1
                    Dim uni As New dUnidades
                    uni.ID = lc.UNIDAD
                    uni = uni.buscar
                    If Not uni Is Nothing Then
                        DataGridView2(columna, fila).Value = uni.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView2(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim pre As New dPresentacionUnidades
                    pre.ID = lc.PRESENTACION
                    pre = pre.buscar
                    If Not pre Is Nothing Then
                        DataGridView2(columna, fila).Value = pre.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView2(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView2(columna, fila).Value = lc.PRECIO
                    columna = columna + 1
                    If lc.MONEDA = 0 Then
                        DataGridView2(columna, fila).Value = "$"
                        columna = columna + 1
                    ElseIf lc.MONEDA = 1 Then
                        DataGridView2(columna, fila).Value = "U$S"
                        columna = columna + 1
                    End If
                    subtotal = lc.CANTIDAD * lc.PRECIO
                    DataGridView2(columna, fila).Value = subtotal
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If DataGridView2.Columns(e.ColumnIndex).Name = "Eliminar" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim lc As New dLineaCompra
            id = row.Cells("Id").Value
            lc.ID = id

            '*** CANCELA LINEA COMPRA **************************************************
            Dim clc As New dCancelaLCompra
            Dim c As New dCompras
            Dim linc As New dLineaCompra
            Dim idcompra As Long = 0
            Dim proveedor As Integer = 0
            Dim producto As Integer = 0
            Dim usuariocreador As Integer = 0
            Dim usuariocancela As Integer = 0
            Dim fechaautoriza As Date = DateAutorizacion.Value.ToString("yyyy-MM-dd")
            Dim fecaut As String
            fecaut = Format(fechaautoriza, "yyyy-MM-dd")

            linc.ID = id
            linc = linc.buscar
            If Not linc Is Nothing Then
                idcompra = linc.IDCOMPRA
                producto = linc.PRODUCTO
            End If
            c.ID = idcompra
            c = c.buscar
            If Not c Is Nothing Then
                proveedor = c.PROVEEDOR
                usuariocreador = c.USUARIOCREADOR
            End If
            usuariocancela = Usuario.ID
            clc.IDCOMPRA = idcompra
            clc.FECHA = fecaut
            clc.PROVEEDOR = proveedor
            clc.PRODUCTO = producto
            clc.USUARIOCREADOR = usuariocreador
            clc.USUARIOCANCELA = usuariocancela
            clc.VISTO = 0
            clc.guardar(Usuario)
            '*** FIN CANCELA LINEA COMPRA *******************************************************

            lc.eliminar(Usuario)

          

            listarlineas()
        End If
    End Sub

    Private Sub DataGridView2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellEndEdit
        If DataGridView2.Columns(e.ColumnIndex).Name = "Cantidad" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim cant As Double = 0
            Dim lc As New dLineaCompra
            id = row.Cells("Id").Value
            cant = row.Cells("Cantidad").Value
            lc.ID = id
            lc.CANTIDAD = cant
            If (lc.cambiarcantidad(Usuario)) Then
                MsgBox("Cantidad modificada", MsgBoxStyle.Information, "Atención")
                listarlineas()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub ButtonAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAutorizar.Click
        'Dim c As New dCompras
        'Dim fechaautoriza As Date = DateAutorizacion.Value.ToString("yyyy-MM-dd")
        'Dim fecaut As String
        'fecaut = Format(fechaautoriza, "yyyy-MM-dd")
        'c.ID = TextIdCompra.Text
        'c.USUARIOAUTORIZA = Usuario.ID
        'c.FECHAAUTORIZA = fecaut
        'If (c.marcarautoriza(Usuario)) Then

        If TextIdCompra.Text <> "" Then
            generaroc()

            '*** Mata los procesos de excel para poder abrir la orden de compra ***
            Dim proceso As System.Diagnostics.Process()
            proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

            For Each opro As System.Diagnostics.Process In proceso
                'antes de iniciar el proceso obtengo la fecha en que inicie el 
                'proceso para detener todos los procesos que excel que inicio
                'mi código durante el proceso
                opro.Kill()

            Next

            'ABRE EL ARCHIVO EXCEL *********************************************
            'Dim Arch1 As String
            'Arch1 = "\\SRVCOLAVECO\D\NET\COMPRAS\OC\OC_" & compraid & ".xls"
            'System.Diagnostics.Process.Start(Arch1)

            '*** Para enviar correo electrónico ********************************
            Dim result = MessageBox.Show("Desea enviar un correo electrónico con la órden de compra?", "Atención!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                Exit Sub
            ElseIf result = DialogResult.No Then
                '--------------------------------------------------------------------------
                Dim comp As New dCompras
                Dim fechaautoriza As Date = DateAutorizacion.Value.ToString("yyyy-MM-dd")
                Dim fecaut As String
                fecaut = Format(fechaautoriza, "yyyy-MM-dd")
                comp.ID = TextIdCompra.Text
                comp.USUARIOAUTORIZA = Usuario.ID
                comp.FECHAAUTORIZA = fecaut
                comp.marcarautoriza(Usuario)
                '--------------------------------------------------------------------------
                limpiar()
                listarcompras()
            ElseIf result = DialogResult.Yes Then
                enviaremail()
                '--------------------------------------------------------------------------
                Dim comp As New dCompras
                Dim fechaautoriza As Date = DateAutorizacion.Value.ToString("yyyy-MM-dd")
                Dim fecaut As String
                fecaut = Format(fechaautoriza, "yyyy-MM-dd")
                comp.ID = TextIdCompra.Text
                comp.USUARIOAUTORIZA = Usuario.ID
                comp.FECHAAUTORIZA = fecaut
                comp.marcarautoriza(Usuario)
                '--------------------------------------------------------------------------
                limpiar()
                listarcompras()
            End If
            '*******************************************************************

        End If

    End Sub
    Private Sub limpiar()
        TextIdCompra.Text = ""
        DateFecha.Value = Now
        TextResponsable.Text = ""
        TextProveedor.Text = ""
        TextObservaciones.Text = ""
        DataGridView2.Rows.Clear()
        DateAutorizacion.Value = Now
    End Sub

    Private Sub ButtonAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAnular.Click
        Dim c As New dCompras
        
        Dim fechaautoriza As Date = DateAutorizacion.Value.ToString("yyyy-MM-dd")
        Dim fecaut As String
        fecaut = Format(fechaautoriza, "yyyy-MM-dd")
        c.ID = TextIdCompra.Text
        c.FECHAAUTORIZA = fecaut
       
        If (c.marcaranulada(Usuario)) Then

            ' CANCELA COMPRA **************************************

            Dim comp As New dCompras
            Dim cc As New dCancelaCompra
            cc.IDCOMPRA = TextIdCompra.Text
            cc.FECHA = fecaut
            comp.ID = TextIdCompra.Text
            comp = comp.buscar
            If Not comp Is Nothing Then
                cc.PROVEEDOR = comp.PROVEEDOR
                cc.USUARIOCREADOR = comp.USUARIOCREADOR
            End If
            cc.USUARIOCANCELA = Usuario.ID
            cc.VISTO = 0
            cc.guardar(Usuario)

            '*** FIN CANCELA COMPRA **********************************

            limpiar()
            listarcompras()
        End If
    End Sub
    Private Sub generaroc()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.Orientation = XlPageOrientation.xlLandscape


        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim oc As Long = TextIdCompra.Text
        Dim fecha As Date = DateAutorizacion.Value
        Dim c As New dCompras
        Dim p As New dProveedores
        Dim usu As New dUsuario
        Dim nombre As String = ""
        Dim direccion As String = ""
        Dim telefono As String = ""
        Dim email As String = ""
        Dim contacto As String = ""
        Dim creador As String = ""

        c.ID = oc
        c = c.buscar
        If Not c Is Nothing Then
            p.ID = c.PROVEEDOR
            p = p.buscar
            If Not p Is Nothing Then
                nombre = p.NOMBRE
                direccion = p.DIRECCION
                telefono = p.TELEFONO
                email = p.EMAIL
                contacto = p.CONTACTO
            End If
            usu.ID = c.USUARIOCREADOR
            usu = usu.buscar
            If Not usu Is Nothing Then
                creador = usu.NOMBRE
            End If
        End If


        x1hoja.Shapes.AddPicture("c:\Debug\encab_compras.jpg", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 520, 60)
        fila = fila + 3

        x1hoja.Cells(1, 1).columnwidth = 20
        x1hoja.Cells(1, 2).columnwidth = 30
        x1hoja.Cells(1, 3).columnwidth = 12
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 15
        x1hoja.Cells(1, 6).columnwidth = 15
        x1hoja.Cells(1, 7).columnwidth = 15

        'x1hoja.Cells(fila, columna).Formula = "Parque El Retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        'x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "Orden de compra Nº " & oc
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "Fecha:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Proveedor:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = nombre
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).WrapText = True
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Dirección:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = direccion
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).WrapText = True
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Teléfono:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = telefono
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).WrapText = True
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Email:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = email
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).WrapText = True
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Contacto:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = contacto
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).WrapText = True
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "Producto"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Detalle"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Cantidad"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Unidad"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Presentación"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Precio unit."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Moneda"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1

        Dim lc As New dLineaCompra
        Dim idcompra As Long = oc
        Dim lista As New ArrayList
        lista = lc.listarxidcompra(idcompra)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each lc In lista
                    Dim pro As New dProductos
                    pro.ID = lc.PRODUCTO
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = pro.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = pro.DETALLE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = lc.CANTIDAD
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    columna = columna + 1
                    Dim uni As New dUnidades
                    uni.ID = lc.UNIDAD
                    uni = uni.buscar
                    If Not uni Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = uni.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If
                    Dim pre As New dPresentacionUnidades
                    pre.ID = lc.PRESENTACION
                    pre = pre.buscar
                    If Not pre Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = pre.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = lc.PRECIO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    columna = columna + 1
                    If lc.MONEDA = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "$"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = 1
                        fila = fila + 1
                    ElseIf lc.MONEDA = 1 Then
                        x1hoja.Cells(fila, columna).Formula = "U$S"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = 1
                        fila = fila + 1
                    End If
                Next
            End If
        End If
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = c.OBSERVACIONES
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
        x1hoja.Cells(fila, columna).WrapText = True
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "Solicita: " & creador
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10


        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
            Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\SRVCOLAVECO\D\NET\COMPRAS\OC\OC_" & idcompra & ".xls")

        'x1hoja.Protect(Password:="pepo", DrawingObjects:=True, _
        'Contents:=True, Scenarios:=True)
        'x1hoja.SaveAs("C:\" & idsol & ".xls")

        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing


    End Sub
    Private Sub abriroc()
        Dim Arch1 As String
        Arch1 = "\\SRVCOLAVECO\D\NET\COMPRAS\OC_" & compraid & ".xls"
        System.Diagnostics.Process.Start(Arch1)
    End Sub
    Private Sub enviaremail()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        Dim email As String = ""
        Dim destinatario As String = ""

        Dim c As New dCompras
        c.ID = compraid
        c = c.buscar
        If Not c Is Nothing Then
            If c.EMAIL <> "" Then
                email = Trim(c.EMAIL)
            End If
            Dim p As New dProveedores
            p.ID = c.PROVEEDOR
            p = p.buscar
            If Not p Is Nothing Then
                destinatario = p.NOMBRE
            End If
        End If

        If email <> "" Then

            'CONFIGURACIÓN DEL STMP 
            '_SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
            _Message.[To].Add(email)
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Orden de compra"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            _Message.Body = "Sres. de" & " " & destinatario & ", " & "por medio del presente correo adjuntamos orden de compra. Desde ya gracias. COLAVECO"
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = "\\SRVCOLAVECO\D\NET\COMPRAS\OC\OC_" & compraid & ".xls" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                marcarenvio()
               
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
                MessageBox.Show("Falla al enviar el correo!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
        Else
            MsgBox("No tiene dirección de correo cargada")
        End If
        email = ""

    End Sub
    Private Sub marcarenvio()
        Dim c As New dCompras
        c.ID = compraid
        c.marcarenviado(Usuario)
    End Sub
End Class