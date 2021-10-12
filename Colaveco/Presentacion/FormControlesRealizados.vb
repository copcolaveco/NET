Public Class FormControlesRealizados
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        limpiar()
    End Sub

#End Region
    Private Sub limpiar()
        DateDesde.Value = Now
        DateHasta.Value = Now
        RadioTodos.Checked = True
        RadioNC.Checked = False
        RadioOM.Checked = False
        TextCantidad.Text = ""
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
    End Sub
    Private Sub controlradios()
        If RadioTodos.Checked = True Then
            RadioNC.Checked = False
            RadioOM.Checked = False
        ElseIf RadioNC.Checked = True Then
            RadioTodos.Checked = False
            RadioOM.Checked = False
        ElseIf RadioOM.Checked = True Then
            RadioTodos.Checked = False
            RadioNC.Checked = False
        End If
    End Sub

    Private Sub RadioTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioTodos.CheckedChanged
        controlradios()
    End Sub

    Private Sub RadioOM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioOM.CheckedChanged
        controlradios()
    End Sub

    Private Sub RadioNC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioNC.CheckedChanged
        controlradios()
    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        If RadioTodos.Checked = True Then
            DataGridView1.Rows.Clear()
            DataGridView2.Rows.Clear()
            listartodos()

        ElseIf RadioNC.Checked = True Then
            DataGridView1.Rows.Clear()
            DataGridView2.Rows.Clear()
            listarnc()

        ElseIf RadioOM.Checked = True Then
            DataGridView1.Rows.Clear()
            DataGridView2.Rows.Clear()
            listarom()

        End If
    End Sub
    Private Sub listartodos()
        Dim ci As New dControldeInformes
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = ci.listarxfecha(fecdesde, fechasta)
        DataGridView1.Rows.Clear()
        Dim cl As Integer = 0
        Dim cal As Integer = 0
        Dim agua As Integer = 0
        Dim sp As Integer = 0
        Dim ser As Integer = 0
        Dim pal As Integer = 0
        Dim tox As Integer = 0
        Dim par As Integer = 0
        Dim bac As Integer = 0
        Dim nut As Integer = 0
        Dim cantidad As Integer = 0

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ci In lista
                    Dim m As New dMuestras
                    Dim ti As New dTipoInforme
                    Dim si As New dSubInforme

                    DataGridView1(columna, fila).Value = ci.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.FECHACONTROL
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.FECHA
                    columna = columna + 1
                    m.ID = ci.MUESTRA
                    m = m.buscar
                    If Not m Is Nothing Then
                        DataGridView1(columna, fila).Value = m.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "vacío"
                        columna = columna + 1
                    End If
                    ti.ID = ci.TIPO
                    ti = ti.buscar
                    DataGridView1(columna, fila).Value = ti.NOMBRE
                    If ci.TIPO = 1 Then
                        cl = cl + 1
                    ElseIf ci.TIPO = 10 Then
                        cal = cal + 1
                    ElseIf ci.TIPO = 3 Then
                        agua = agua + 1
                    ElseIf ci.TIPO = 7 Then
                        sp = sp + 1
                    ElseIf ci.TIPO = 8 Then
                        ser = ser + 1
                    ElseIf ci.TIPO = 5 Then
                        pal = pal + 1
                    ElseIf ci.TIPO = 9 Then
                        tox = tox + 1
                    ElseIf ci.TIPO = 6 Then
                        par = par + 1
                    ElseIf ci.TIPO = 4 Then
                        bac = bac + 1
                    ElseIf ci.TIPO = 13 Then
                        nut = nut + 1
                    End If
                    columna = columna + 1
                    si.ID = ci.SUBTIPO
                    si = si.buscar
                    If Not si Is Nothing Then
                        DataGridView1(columna, fila).Value = si.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If ci.RESULTADO = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ci.COINCIDE = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ci.OM = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ci.NC = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.OBSERVACIONES
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView2.Rows.Clear()
                DataGridView2.Rows.Add(1)
                DataGridView2(0, 0).Value = cl
                DataGridView2(1, 0).Value = cal
                DataGridView2(2, 0).Value = agua
                DataGridView2(3, 0).Value = sp
                DataGridView2(4, 0).Value = ser
                DataGridView2(5, 0).Value = pal
                DataGridView2(6, 0).Value = tox
                DataGridView2(7, 0).Value = par
                DataGridView2(8, 0).Value = bac
                DataGridView2(9, 0).Value = nut
                cantidad = cl + cal + agua + sp + ser + pal + tox + par + bac + nut
                TextCantidad.Text = cantidad

            End If
        End If
    End Sub
    Private Sub listarnc()
        Dim ci As New dControldeInformes
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = ci.listarxfechanc(fecdesde, fechasta)
        DataGridView1.Rows.Clear()
        Dim cl As Integer = 0
        Dim cal As Integer = 0
        Dim agua As Integer = 0
        Dim sp As Integer = 0
        Dim ser As Integer = 0
        Dim pal As Integer = 0
        Dim tox As Integer = 0
        Dim par As Integer = 0
        Dim bac As Integer = 0
        Dim nut As Integer = 0
        Dim cantidad As Integer = 0

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ci In lista
                    Dim m As New dMuestras
                    Dim ti As New dTipoInforme
                    Dim si As New dSubInforme

                    DataGridView1(columna, fila).Value = ci.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.FECHACONTROL
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.FECHA
                    columna = columna + 1
                    m.ID = ci.MUESTRA
                    m = m.buscar
                    If Not m Is Nothing Then
                        DataGridView1(columna, fila).Value = m.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "vacío"
                        columna = columna + 1
                    End If
                    ti.ID = ci.TIPO
                    ti = ti.buscar
                    DataGridView1(columna, fila).Value = ti.NOMBRE
                    If ci.TIPO = 1 Then
                        cl = cl + 1
                    ElseIf ci.TIPO = 10 Then
                        cal = cal + 1
                    ElseIf ci.TIPO = 3 Then
                        agua = agua + 1
                    ElseIf ci.TIPO = 7 Then
                        sp = sp + 1
                    ElseIf ci.TIPO = 8 Then
                        ser = ser + 1
                    ElseIf ci.TIPO = 5 Then
                        pal = pal + 1
                    ElseIf ci.TIPO = 9 Then
                        tox = tox + 1
                    ElseIf ci.TIPO = 6 Then
                        par = par + 1
                    ElseIf ci.TIPO = 4 Then
                        bac = bac + 1
                    ElseIf ci.TIPO = 13 Then
                        nut = nut + 1
                    End If
                    columna = columna + 1
                    si.ID = ci.SUBTIPO
                    si = si.buscar
                    DataGridView1(columna, fila).Value = si.NOMBRE
                    columna = columna + 1
                    If ci.RESULTADO = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ci.COINCIDE = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ci.OM = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ci.NC = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.OBSERVACIONES
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView2.Rows.Clear()
                DataGridView2.Rows.Add(1)
                DataGridView2(0, 0).Value = cl
                DataGridView2(1, 0).Value = cal
                DataGridView2(2, 0).Value = agua
                DataGridView2(3, 0).Value = sp
                DataGridView2(4, 0).Value = ser
                DataGridView2(5, 0).Value = pal
                DataGridView2(6, 0).Value = tox
                DataGridView2(7, 0).Value = par
                DataGridView2(8, 0).Value = bac
                DataGridView2(9, 0).Value = nut
                cantidad = cl + cal + agua + sp + ser + pal + tox + par + bac + nut
                TextCantidad.Text = cantidad

            End If
        End If
    End Sub
    Private Sub listarom()
        Dim ci As New dControldeInformes
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = ci.listarxfechaom(fecdesde, fechasta)
        DataGridView1.Rows.Clear()
        Dim cl As Integer = 0
        Dim cal As Integer = 0
        Dim agua As Integer = 0
        Dim sp As Integer = 0
        Dim ser As Integer = 0
        Dim pal As Integer = 0
        Dim tox As Integer = 0
        Dim par As Integer = 0
        Dim bac As Integer = 0
        Dim nut As Integer = 0
        Dim cantidad As Integer = 0

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ci In lista
                    Dim m As New dMuestras
                    Dim ti As New dTipoInforme
                    Dim si As New dSubInforme

                    DataGridView1(columna, fila).Value = ci.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.FECHACONTROL
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.FECHA
                    columna = columna + 1
                    m.ID = ci.MUESTRA
                    m = m.buscar
                    If Not m Is Nothing Then
                        DataGridView1(columna, fila).Value = m.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "vacío"
                        columna = columna + 1
                    End If
                    ti.ID = ci.TIPO
                    ti = ti.buscar
                    DataGridView1(columna, fila).Value = ti.NOMBRE
                    If ci.TIPO = 1 Then
                        cl = cl + 1
                    ElseIf ci.TIPO = 10 Then
                        cal = cal + 1
                    ElseIf ci.TIPO = 3 Then
                        agua = agua + 1
                    ElseIf ci.TIPO = 7 Then
                        sp = sp + 1
                    ElseIf ci.TIPO = 8 Then
                        ser = ser + 1
                    ElseIf ci.TIPO = 5 Then
                        pal = pal + 1
                    ElseIf ci.TIPO = 9 Then
                        tox = tox + 1
                    ElseIf ci.TIPO = 6 Then
                        par = par + 1
                    ElseIf ci.TIPO = 4 Then
                        bac = bac + 1
                    ElseIf ci.TIPO = 13 Then
                        nut = nut + 1
                    End If
                    columna = columna + 1
                    si.ID = ci.SUBTIPO
                    si = si.buscar
                    DataGridView1(columna, fila).Value = si.NOMBRE
                    columna = columna + 1
                    If ci.RESULTADO = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ci.COINCIDE = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ci.OM = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If ci.NC = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ci.OBSERVACIONES
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView2.Rows.Clear()
                DataGridView2.Rows.Add(1)
                DataGridView2(0, 0).Value = cl
                DataGridView2(1, 0).Value = cal
                DataGridView2(2, 0).Value = agua
                DataGridView2(3, 0).Value = sp
                DataGridView2(4, 0).Value = ser
                DataGridView2(5, 0).Value = pal
                DataGridView2(6, 0).Value = tox
                DataGridView2(7, 0).Value = par
                DataGridView2(8, 0).Value = bac
                DataGridView2(9, 0).Value = nut
                cantidad = cl + cal + agua + sp + ser + pal + tox + par + bac + nut
                TextCantidad.Text = cantidad

            End If
        End If
    End Sub
    
End Class