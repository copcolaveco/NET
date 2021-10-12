Public Class FormActividades
    Private _usuario As dUsuario
    Private _anio As Integer
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
        Usuario = u
        calcularano()
        cargarcombo()
        cargarcombodimension()
        listar()

    End Sub
#End Region
    Private Sub calcularano()
        Dim hoy As Date = Now
        Dim ano As Integer = 0
        ano = hoy.Year
        _anio = hoy.Year
        NumericAno.Value = ano
    End Sub
    Private Sub listar()
        Dim a As New dActividades
        Dim lista As New ArrayList
        lista = a.listarxano(_anio)

        DataGridView1.ColumnCount = 9
        DataGridView1.Columns(0).Name = "Id"
        DataGridView1.Columns(0).Width = 50
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Name = "Nombre"
        DataGridView1.Columns(1).Width = 250
        DataGridView1.Columns(2).Name = "Indicador"
        DataGridView1.Columns(2).Width = 250
        DataGridView1.Columns(3).Name = "Año"
        DataGridView1.Columns(3).Width = 50
        DataGridView1.Columns(4).Name = "Objetivo específico"
        DataGridView1.Columns(4).Width = 250
        DataGridView1.Columns(5).Name = "Meta"
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Columns(6).Name = "Responsable"
        DataGridView1.Columns(6).Width = 150
        DataGridView1.Columns(7).Name = "Plazo"
        DataGridView1.Columns(7).Width = 70
        DataGridView1.Columns(8).Name = "Finaliza"
        DataGridView1.Columns(8).Width = 50

        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each a In lista
                    Dim oe As New dObjEspecifico
                    DataGridView1(columna, fila).Value = a.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.NOMBRE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.INDICADOR
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.ANO
                    columna = columna + 1
                    oe.ID = a.IDOBJESPECIFICO
                    oe = oe.buscar
                    If Not oe Is Nothing Then
                        DataGridView1(columna, fila).Value = oe.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = a.META
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.RESPONSABLE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.PLAZO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.FINALIZA
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(2), System.ComponentModel.ListSortDirection.Descending)

            End If
        End If
    End Sub
    Public Sub cargarcombo()
        ComboObjEsp.Items.Clear()
        Dim oe As New dObjEspecifico
        Dim lista As New ArrayList
        lista = oe.listarxano(_anio)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each oe In lista
                    ComboObjEsp.Items.Add(oe)
                Next
            End If
        End If
    End Sub
    Public Sub cargarcombodimension()
        ComboDimension.Items.Clear()
        Dim d As New dDimension
        Dim lista As New ArrayList
        lista = d.listarxano(_anio)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each d In lista
                    ComboDimension.Items.Add(d)
                Next
            End If
        End If
    End Sub
    Public Sub cargarcombotodos()
        ComboObjEsp.Items.Clear()
        Dim oe As New dObjEspecifico
        Dim lista As New ArrayList
        lista = oe.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each oe In lista
                    ComboObjEsp.Items.Add(oe)
                Next
            End If
        End If
    End Sub
    Public Sub cargarcombotodos2()
        ComboDimension.Items.Clear()
        Dim d As New dDimension
        Dim lista As New ArrayList
        lista = d.listarxano(_anio)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each d In lista
                    ComboDimension.Items.Add(d)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        TextIndicador.Text = ""
        ComboDimension.Text = ""
        ComboObjEsp.Text = ""
        TextMeta.Text = ""
        TextAceptable.Text = ""
        TextResponsable.Text = ""
        calcularano()
        cargarcombo()
        listar()
        ComboObjEsp.Focus()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim dimension As dDimension = CType(ComboDimension.SelectedItem, dDimension)
        Dim objesp As dObjEspecifico = CType(ComboObjEsp.SelectedItem, dObjEspecifico)
        If TextNombre.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el nombre", MsgBoxStyle.Exclamation, "Atención") : TextNombre.Focus() : Exit Sub
        Dim nombre As String = TextNombre.Text.Trim
        If TextIndicador.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el indicador", MsgBoxStyle.Exclamation, "Atención") : TextIndicador.Focus() : Exit Sub
        Dim indicador As String = TextIndicador.Text.Trim
        Dim ano As Integer = NumericAno.Value
        If TextMeta.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado una meta", MsgBoxStyle.Exclamation, "Atención") : TextMeta.Focus() : Exit Sub
        Dim meta As Integer = TextMeta.Text
        If TextAceptable.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado una meta aceptable", MsgBoxStyle.Exclamation, "Atención") : TextAceptable.Focus() : Exit Sub
        Dim aceptable As Integer = TextAceptable.Text
        If TextResponsable.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado un responsable", MsgBoxStyle.Exclamation, "Atención") : TextResponsable.Focus() : Exit Sub
        Dim responsable As String = TextResponsable.Text
        Dim plazo As Date = DatePlazo.Value.ToString("yyyy-MM-dd")
        Dim finaliza As Integer = NumericFinaliza.Value
        Dim fecha As String
        fecha = Format(plazo, "yyyy-MM-dd")
        If TextId.Text.Trim.Length > 0 Then
            Dim a As New dActividades
            Dim id As Long = CType(TextId.Text.Trim, Long)
            a.ID = id
            If Not dimension Is Nothing Then
                a.IDDIMENSION = dimension.ID
            Else
                MsgBox("Seleccione una dimensión", MsgBoxStyle.Exclamation, "Atención") : ComboDimension.Focus() : Exit Sub
            End If
            If Not objesp Is Nothing Then
                a.IDOBJESPECIFICO = objesp.ID
            Else
                MsgBox("Seleccione un objetivo específico", MsgBoxStyle.Exclamation, "Atención") : ComboObjEsp.Focus() : Exit Sub
            End If
            a.NOMBRE = nombre
            a.INDICADOR = indicador
            a.META = meta
            a.ACEPTABLE = aceptable
            a.RESPONSABLE = responsable
            a.PLAZO = fecha
            a.ANO = ano
            a.FINALIZA = finaliza
            If (a.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim a As New dActividades
            If Not dimension Is Nothing Then
                a.IDDIMENSION = dimension.ID
            Else
                MsgBox("Seleccione una dimensión", MsgBoxStyle.Exclamation, "Atención") : ComboDimension.Focus() : Exit Sub
            End If
            If Not objesp Is Nothing Then
                a.IDOBJESPECIFICO = objesp.ID
            Else
                MsgBox("Seleccione un objetivo específico", MsgBoxStyle.Exclamation, "Atención") : ComboObjEsp.Focus() : Exit Sub
            End If
            a.NOMBRE = nombre
            a.INDICADOR = indicador
            a.META = meta
            a.ACEPTABLE = aceptable
            a.RESPONSABLE = responsable
            a.PLAZO = fecha
            a.ANO = ano
            a.FINALIZA = finaliza
            If (a.guardar(Usuario)) Then
                Dim act As New dActividades
                act = act.buscarultima
                Dim idact As Long = 0
                If Not act Is Nothing Then
                    idact = act.ID
                End If
                Dim i As New dIndicadores
                For x = 1 To 12
                    i.IDACTIVIDAD = idact
                    i.MES = x
                    i.INDICADOR = 0
                    i.guardar(Usuario)
                Next x
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub NumericAno_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericAno.ValueChanged
        _anio = NumericAno.Value
        cargarcombodimension()
        cargarcombo()
        listar()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Id" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dActividades
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = a.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                Dim oe As dObjEspecifico
                cargarcombotodos()
                For Each oe In ComboObjEsp.Items
                    If oe.ID = a.IDOBJESPECIFICO Then
                        ComboObjEsp.SelectedItem = oe
                        Exit For
                    End If
                Next
                TextNombre.Text = a.NOMBRE
                TextIndicador.Text = a.INDICADOR
                NumericAno.Value = a.ANO
                TextMeta.Text = a.META
                TextAceptable.Text = a.ACEPTABLE
                TextResponsable.Text = a.RESPONSABLE
                DatePlazo.Value = a.PLAZO
                NumericFinaliza.Value = a.FINALIZA
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dActividades
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = a.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                Dim oe As dObjEspecifico
                cargarcombotodos()
                For Each oe In ComboObjEsp.Items
                    If oe.ID = a.IDOBJESPECIFICO Then
                        ComboObjEsp.SelectedItem = oe
                        Exit For
                    End If
                Next
                TextNombre.Text = a.NOMBRE
                TextIndicador.Text = a.INDICADOR
                NumericAno.Value = a.ANO
                TextMeta.Text = a.META
                TextAceptable.Text = a.ACEPTABLE
                TextResponsable.Text = a.RESPONSABLE
                DatePlazo.Value = a.PLAZO
                NumericFinaliza.Value = a.FINALIZA
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Año" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dActividades
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = a.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                Dim oe As dObjEspecifico
                cargarcombotodos()
                For Each oe In ComboObjEsp.Items
                    If oe.ID = a.IDOBJESPECIFICO Then
                        ComboObjEsp.SelectedItem = oe
                        Exit For
                    End If
                Next
                TextNombre.Text = a.NOMBRE
                TextIndicador.Text = a.INDICADOR
                NumericAno.Value = a.ANO
                TextMeta.Text = a.META
                TextAceptable.Text = a.ACEPTABLE
                TextResponsable.Text = a.RESPONSABLE
                DatePlazo.Value = a.PLAZO
                NumericFinaliza.Value = a.FINALIZA
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Objetivo específico" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dActividades
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = a.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                Dim oe As dObjEspecifico
                cargarcombotodos()
                For Each oe In ComboObjEsp.Items
                    If oe.ID = a.IDOBJESPECIFICO Then
                        ComboObjEsp.SelectedItem = oe
                        Exit For
                    End If
                Next
                TextNombre.Text = a.NOMBRE
                TextIndicador.Text = a.INDICADOR
                NumericAno.Value = a.ANO
                TextMeta.Text = a.META
                TextAceptable.Text = a.ACEPTABLE
                TextResponsable.Text = a.RESPONSABLE
                DatePlazo.Value = a.PLAZO
                NumericFinaliza.Value = a.FINALIZA
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Meta" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dActividades
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = a.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                Dim oe As dObjEspecifico
                cargarcombotodos()
                For Each oe In ComboObjEsp.Items
                    If oe.ID = a.IDOBJESPECIFICO Then
                        ComboObjEsp.SelectedItem = oe
                        Exit For
                    End If
                Next
                TextNombre.Text = a.NOMBRE
                TextIndicador.Text = a.INDICADOR
                NumericAno.Value = a.ANO
                TextMeta.Text = a.META
                TextAceptable.Text = a.ACEPTABLE
                TextResponsable.Text = a.RESPONSABLE
                DatePlazo.Value = a.PLAZO
                NumericFinaliza.Value = a.FINALIZA
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Responsable" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dActividades
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = a.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                Dim oe As dObjEspecifico
                cargarcombotodos()
                For Each oe In ComboObjEsp.Items
                    If oe.ID = a.IDOBJESPECIFICO Then
                        ComboObjEsp.SelectedItem = oe
                        Exit For
                    End If
                Next
                TextNombre.Text = a.NOMBRE
                TextIndicador.Text = a.INDICADOR
                NumericAno.Value = a.ANO
                TextMeta.Text = a.META
                TextAceptable.Text = a.ACEPTABLE
                TextResponsable.Text = a.RESPONSABLE
                DatePlazo.Value = a.PLAZO
                NumericFinaliza.Value = a.FINALIZA
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Plazo" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dActividades
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = a.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                Dim oe As dObjEspecifico
                cargarcombotodos()
                For Each oe In ComboObjEsp.Items
                    If oe.ID = a.IDOBJESPECIFICO Then
                        ComboObjEsp.SelectedItem = oe
                        Exit For
                    End If
                Next
                TextNombre.Text = a.NOMBRE
                TextIndicador.Text = a.INDICADOR
                NumericAno.Value = a.ANO
                TextMeta.Text = a.META
                TextAceptable.Text = a.ACEPTABLE
                TextResponsable.Text = a.RESPONSABLE
                DatePlazo.Value = a.PLAZO
                NumericFinaliza.Value = a.FINALIZA
            End If
        End If
    End Sub

    Private Sub ComboDimension_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDimension.SelectedIndexChanged
        listarpordimension()

        ComboObjEsp.Text = ""

        Dim dimension As dDimension = CType(ComboDimension.SelectedItem, dDimension)
        Dim iddimension As Integer = 0
        iddimension = dimension.ID

        Dim a As New dActividades
        Dim lista As New ArrayList
        lista = a.listarxdimension(iddimension)

        DataGridView1.ColumnCount = 8
        DataGridView1.Columns(0).Name = "Id"
        DataGridView1.Columns(0).Width = 50
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Name = "Nombre"
        DataGridView1.Columns(1).Width = 250
        DataGridView1.Columns(2).Name = "Indicador"
        DataGridView1.Columns(2).Width = 250
        DataGridView1.Columns(3).Name = "Año"
        DataGridView1.Columns(3).Width = 50
        DataGridView1.Columns(4).Name = "Objetivo específico"
        DataGridView1.Columns(4).Width = 250
        DataGridView1.Columns(5).Name = "Meta"
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Columns(6).Name = "Responsable"
        DataGridView1.Columns(6).Width = 150
        DataGridView1.Columns(7).Name = "Plazo"
        DataGridView1.Columns(7).Width = 70

        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                Dim oe As New dObjEspecifico
                For Each a In lista
                    DataGridView1(columna, fila).Value = a.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.NOMBRE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.INDICADOR
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.ANO
                    columna = columna + 1
                    oe.ID = a.IDOBJESPECIFICO
                    oe = oe.buscar
                    If Not oe Is Nothing Then
                        DataGridView1(columna, fila).Value = oe.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = a.META
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.RESPONSABLE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.PLAZO
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(2), System.ComponentModel.ListSortDirection.Descending)

            End If
        End If
    End Sub

    Private Sub listarpordimension()
        Dim dimension As dDimension = CType(ComboDimension.SelectedItem, dDimension)
        Dim iddimension = dimension.ID
        ComboObjEsp.Items.Clear()
        Dim oe As New dObjEspecifico
        Dim lista As New ArrayList
        lista = oe.listarxdimension(iddimension)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each oe In lista
                    ComboObjEsp.Items.Add(oe)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text.Length > 0 Then
            Dim a As New dActividades
            Dim id As Long = CType(TextId.Text, Long)
            a.ID = id
            If (a.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        listar()
    End Sub

    Private Sub ButtonTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodos.Click
        limpiar()
    End Sub

    Private Sub ComboObjEsp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboObjEsp.SelectedIndexChanged

        Dim objetivoe As dObjEspecifico = CType(ComboObjEsp.SelectedItem, dObjEspecifico)
        Dim idobjetivoe As Integer = 0
        idobjetivoe = objetivoe.ID

        Dim a As New dActividades
        Dim lista As New ArrayList
        lista = a.listarxobjesp(idobjetivoe)

        DataGridView1.ColumnCount = 8
        DataGridView1.Columns(0).Name = "Id"
        DataGridView1.Columns(0).Width = 50
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Name = "Nombre"
        DataGridView1.Columns(1).Width = 250
        DataGridView1.Columns(2).Name = "Indicador"
        DataGridView1.Columns(2).Width = 250
        DataGridView1.Columns(3).Name = "Año"
        DataGridView1.Columns(3).Width = 50
        DataGridView1.Columns(4).Name = "Objetivo específico"
        DataGridView1.Columns(4).Width = 250
        DataGridView1.Columns(5).Name = "Meta"
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Columns(6).Name = "Responsable"
        DataGridView1.Columns(6).Width = 150
        DataGridView1.Columns(7).Name = "Plazo"
        DataGridView1.Columns(7).Width = 70

        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                Dim oe As New dObjEspecifico
                For Each a In lista
                    DataGridView1(columna, fila).Value = a.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.NOMBRE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.INDICADOR
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.ANO
                    columna = columna + 1
                    oe.ID = a.IDOBJESPECIFICO
                    oe = oe.buscar
                    If Not oe Is Nothing Then
                        DataGridView1(columna, fila).Value = oe.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = a.META
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.RESPONSABLE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.PLAZO
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(2), System.ComponentModel.ListSortDirection.Descending)

            End If
        End If
    End Sub

    Private Sub TextNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextNombre.TextChanged

    End Sub
End Class