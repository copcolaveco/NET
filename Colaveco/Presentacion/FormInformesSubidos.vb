Imports System.Net.FtpWebRequest
Imports System.Net
Imports System.IO
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Public Class FormInformesSubidos
    Dim cantidadinf As String = ""
    Dim fila As Integer = 0
    Dim columna As Integer = 0

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        DateDesde.Value = Now
        DateHasta.Value = Now

    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        cantidadinf = ""
        LabelLeyenda.Text = ""
        TextCantidad.Text = ""
        fila = 0
        columna = 0
        DataGridView1.Rows.Clear()
        LabelLeyenda.Text = "Procesando información..."
        listaragro()
        listaragua()
        listarambiental()
        listarantibiograma()
        listarcalidad()
        listarcontrol()
        listarlactometros()
        listarpal()
        listarparasitologia()
        listarpatologia()
        listarproductos()
        listarserologia()
        listarbrucelosisleche()
        listarnutricion()
        listarsuelos()
        listarotros()

        LabelLeyenda.Text = "Proceso finalizado"
        TextCantidad.Text = cantidadinf
    End Sub
    Private Sub listaragro()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim agro As New dAgroNutricionWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = agro.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Agro: " & lista.Count & " / "
                For Each agro In lista

                    DataGridView1(columna, fila).Value = agro.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = agro.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = agro.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Agro Nutrición"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = agro.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listaragua()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim agua As New dAguaWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0

        lista = agua.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Agua: " & lista.Count & " / "
                For Each agua In lista

                    DataGridView1(columna, fila).Value = agua.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = agua.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = agua.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Agua"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = agua.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarambiental()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim amb As New dAmbientalWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = amb.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Ambiental: " & lista.Count & " / "
                For Each amb In lista

                    DataGridView1(columna, fila).Value = amb.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = amb.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = amb.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Ambiental"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = amb.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarantibiograma()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim atb As New dAntibiogramaWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = atb.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Antibiograma: " & lista.Count & " / "
                For Each atb In lista

                    DataGridView1(columna, fila).Value = atb.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = atb.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = atb.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Antibiograma"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = atb.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarcalidad()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim cal As New dCalidadWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = cal.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Calidad: " & lista.Count & " / "
                For Each cal In lista

                    DataGridView1(columna, fila).Value = cal.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cal.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cal.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Calidad de leche"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = cal.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarcontrol()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim control As New dControlLecheroWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = control.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Control: " & lista.Count & " / "
                For Each control In lista

                    DataGridView1(columna, fila).Value = control.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = control.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = control.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Control lechero"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = control.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarlactometros()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim lact As New dLactometrosWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = lact.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Lactómetros: " & lista.Count & " / "
                For Each lact In lista

                    DataGridView1(columna, fila).Value = lact.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lact.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = lact.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Lactómetros - chequeo - maquina"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = lact.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarotros()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim otros As New dOtrosServiciosWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = otros.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Otros: " & lista.Count & " / "
                For Each otros In lista

                    DataGridView1(columna, fila).Value = otros.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = otros.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = otros.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Otros servicios"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = otros.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarpal()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim pal As New dPalWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = pal.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "PAL: " & lista.Count & " / "
                For Each pal In lista

                    DataGridView1(columna, fila).Value = pal.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pal.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pal.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "PAL"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = pal.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarparasitologia()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim par As New dParasitologiaWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = par.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Parasitología: " & lista.Count & " / "
                For Each par In lista

                    DataGridView1(columna, fila).Value = par.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = par.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = par.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Parasitología"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = par.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarpatologia()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim pat As New dPatologiaWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = pat.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Patología: " & lista.Count & " / "
                For Each pat In lista

                    DataGridView1(columna, fila).Value = pat.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pat.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pat.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Patología"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = pat.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarproductos()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim sp As New dSubproductosWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = sp.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Sub-productos: " & lista.Count & " / "
                For Each sp In lista

                    DataGridView1(columna, fila).Value = sp.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = sp.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = sp.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Subprodúctos"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = sp.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarserologia()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim ser As New dSerologiaWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = ser.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Serología: " & lista.Count & " / "
                For Each ser In lista

                    DataGridView1(columna, fila).Value = ser.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ser.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ser.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Serología"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = ser.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarbrucelosisleche()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim brucleche As New dBrucelosisLecheWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = brucleche.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Brucelosis leche: " & lista.Count & " / "
                For Each brucleche In lista

                    DataGridView1(columna, fila).Value = brucleche.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = brucleche.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = brucleche.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Brucelosis leche"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = brucleche.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarnutricion()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim nut As New dAgroNutricionWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = nut.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Agro - Nutrición: " & lista.Count & " / "
                For Each nut In lista

                    DataGridView1(columna, fila).Value = nut.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nut.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nut.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Agro - Nutrición"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = nut.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub
    Private Sub listarsuelos()
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim sue As New dAgroSuelosWeb_com
        Dim lista As New ArrayList
        'Dim fila As Integer = 0
        'Dim columna As Integer = 0
        lista = sue.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Add(lista.Count)
            End If
        End If

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                cantidadinf = cantidadinf & "Agro - Suelos: " & lista.Count & " / "
                For Each sue In lista

                    DataGridView1(columna, fila).Value = sue.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = sue.FECHA_EMISION
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = sue.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Agro - Suelos"
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = sue.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    sa = Nothing
                    p = Nothing
                Next
            End If
        End If
        lista = Nothing

    End Sub

    Private Sub ButtonExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcel.Click
        informe_excel()
    End Sub
    Private Sub informe_excel()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 10
        x1hoja.Cells(1, 3).columnwidth = 10
        x1hoja.Cells(1, 4).columnwidth = 20
        x1hoja.Cells(1, 5).columnwidth = 30

        Dim filaexcel As Integer = 1
        Dim columnaexcel As Integer = 1

        x1hoja.Cells(filaexcel, columnaexcel).formula = "LISTADO DE INFORMES SUBIDOS A LA WEB" & " - " & Now
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        'x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        filaexcel = filaexcel + 2
        x1hoja.Cells(filaexcel, columnaexcel).formula = "ID"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        columnaexcel = columnaexcel + 1
        x1hoja.Cells(filaexcel, columnaexcel).formula = "FECHA"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        columnaexcel = columnaexcel + 1
        x1hoja.Cells(filaexcel, columnaexcel).formula = "FICHA"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        columnaexcel = columnaexcel + 1
        x1hoja.Cells(filaexcel, columnaexcel).formula = "ANALISIS"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        columnaexcel = columnaexcel + 1
        x1hoja.Cells(filaexcel, columnaexcel).formula = "CLIENTE"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        filaexcel = filaexcel + 1
        columnaexcel = 1

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim agro As New dAgroNutricionWeb_com
        Dim agua As New dAguaWeb_com
        Dim amb As New dAmbientalWeb_com
        Dim atb As New dAntibiogramaWeb_com
        Dim cal As New dCalidadWeb_com
        Dim control As New dControlLecheroWeb_com
        Dim lact As New dLactometrosWeb_com
        Dim otros As New dOtrosServiciosWeb_com
        Dim pal As New dPalWeb_com
        Dim par As New dParasitologiaWeb_com
        Dim pat As New dPatologiaWeb_com
        Dim sp As New dSubproductosWeb_com
        Dim ser As New dSerologiaWeb_com
        Dim brucleche As New dBrucelosisLecheWeb_com
        Dim nut As New dAgroNutricionWeb_com
        Dim sue As New dAgroSuelosWeb_com
        Dim lista As New ArrayList

        lista = agro.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each agro In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = agro.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = agro.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = agro.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Agronutrición"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = agro.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing

        lista = agua.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each agua In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = agua.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = agua.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = agua.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Agua"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = agua.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing

        lista = amb.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each amb In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = amb.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = amb.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = amb.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Ambiental"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = amb.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing

        lista = atb.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each atb In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = atb.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = atb.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = atb.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Antibiograma"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = atb.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing

        lista = cal.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each cal In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = cal.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = cal.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = cal.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Calidad de leche"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = cal.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing

        lista = control.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each control In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = control.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = control.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = control.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Control lechero"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = control.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing

        lista = lact.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each lact In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = lact.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = lact.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = lact.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Lactómetros"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = lact.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing

        lista = otros.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each otros In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = otros.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = otros.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = otros.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Otros servicios"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = otros.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing

        lista = pal.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each pal In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = pal.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = pal.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = pal.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "PAL"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = pal.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing

        lista = par.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each par In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = par.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = par.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = par.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Parasitología"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = par.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing

        lista = pat.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each pat In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = pat.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = pat.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = pat.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Patología"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = pat.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing

        lista = sp.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sp In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = sp.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = sp.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = sp.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Subprodúctos"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = sp.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing

        lista = ser.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ser In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = ser.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = ser.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = ser.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Serología"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = ser.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing

        lista = brucleche.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each brucleche In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = brucleche.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = brucleche.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = brucleche.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Brucelosis leche"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = brucleche.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing


        lista = nut.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each nut In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = nut.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = nut.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = nut.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Agro - Nutrición"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = nut.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing


        lista = sue.listarporfecha(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sue In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = sue.ID
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = sue.FECHA_EMISION
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = sue.FICHA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "Agro - Suelos"
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = sue.FICHA
                    sa = sa.buscar
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(filaexcel, columnaexcel).formula = p.NOMBRE
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    Else
                        x1hoja.Cells(filaexcel, columnaexcel).formula = ""
                        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                        filaexcel = filaexcel + 1
                        columnaexcel = 1
                    End If
                    sa = Nothing
                    p = Nothing

                Next
            End If
        End If
        lista = Nothing


        x1app.Visible = True
        x1libro.PrintPreview()

        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing

    End Sub



End Class