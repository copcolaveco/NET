Public Class FormObjEspecifico
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
        Dim oe As New dObjEspecifico
        Dim lista As New ArrayList
        lista = oe.listarxano(_anio)

        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.ColumnCount = 5
                DataGridView1.Columns(0).Name = "Id"
                DataGridView1.Columns(0).Width = 50
                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(1).Name = "Obj. Específico"
                DataGridView1.Columns(1).Width = 200
                DataGridView1.Columns(2).Name = "ObjGral"
                DataGridView1.Columns(2).HeaderText = "Obj. General"
                DataGridView1.Columns(2).Width = 200
                DataGridView1.Columns(3).Name = "Dimension"
                DataGridView1.Columns(3).HeaderText = "Dimensión"
                DataGridView1.Columns(3).Width = 100
                DataGridView1.Columns(4).Name = "Año"
                DataGridView1.Columns(4).Width = 50
                DataGridView1.Rows.Add(lista.Count)
                Dim og As New dObjGral
                Dim dimension As New dDimension
                For Each oe In lista
                    DataGridView1(columna, fila).Value = oe.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = oe.NOMBRE
                    columna = columna + 1
                    og.ID = oe.IDOBJGRAL
                    og = og.buscar
                    If Not og Is Nothing Then
                        DataGridView1(columna, fila).Value = og.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    dimension.ID = oe.IDDIMENSION
                    dimension = dimension.buscar
                    If Not dimension Is Nothing Then
                        DataGridView1(columna, fila).Value = dimension.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = oe.ANO
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(3), System.ComponentModel.ListSortDirection.Descending)

            End If
        End If
    End Sub
    Public Sub cargarcombo()
        ComboObjGral.Items.Clear()
        Dim og As New dObjGral
        Dim lista As New ArrayList
        lista = og.listarxano(_anio)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each og In lista
                    ComboObjGral.Items.Add(og)
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

    Private Sub NumericAno_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericAno.ValueChanged
        _anio = NumericAno.Value
        cargarcombodimension()
        cargarcombo()
        listar()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        ComboObjGral.Text = ""
        calcularano()
        cargarcombo()
        listar()
        ComboObjGral.Focus()
    End Sub
    Private Sub guardar()
        Dim dimension As dDimension = CType(ComboDimension.SelectedItem, dDimension)
        Dim objgral As dObjGral = CType(ComboObjGral.SelectedItem, dObjGral)
        If TextNombre.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el nombre", MsgBoxStyle.Exclamation, "Atención") : TextNombre.Focus() : Exit Sub
        Dim nombre As String = TextNombre.Text.Trim
        Dim ano As Integer = NumericAno.Value
        If TextId.Text.Trim.Length > 0 Then
            Dim oe As New dObjEspecifico
            Dim id As Long = CType(TextId.Text.Trim, Long)
            oe.ID = id
            If Not dimension Is Nothing Then
                oe.IDDIMENSION = dimension.ID
            Else
                MsgBox("Seleccione una dimensión", MsgBoxStyle.Exclamation, "Atención") : ComboDimension.Focus() : Exit Sub
            End If
            If Not objgral Is Nothing Then
                oe.IDOBJGRAL = objgral.ID
            Else
                MsgBox("Seleccione un objetivo general", MsgBoxStyle.Exclamation, "Atención") : ComboObjGral.Focus() : Exit Sub
            End If
            oe.NOMBRE = nombre
            oe.ANO = ano
            If (oe.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim oe As New dObjEspecifico
            If Not dimension Is Nothing Then
                oe.IDDIMENSION = dimension.ID
            Else
                MsgBox("Seleccione una dimensión", MsgBoxStyle.Exclamation, "Atención") : ComboDimension.Focus() : Exit Sub
            End If
            If Not objgral Is Nothing Then
                oe.IDOBJGRAL = objgral.ID
            Else
                MsgBox("Seleccione un objetivo general", MsgBoxStyle.Exclamation, "Atención") : ComboObjGral.Focus() : Exit Sub
            End If
            oe.NOMBRE = nombre
            oe.ANO = ano
            If (oe.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Public Sub cargarcombotodos()
        ComboObjGral.Items.Clear()
        Dim og As New dObjGral
        Dim lista As New ArrayList
        lista = og.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each og In lista
                    ComboObjGral.Items.Add(og)
                Next
            End If
        End If
    End Sub
    Public Sub cargarcombotodos2()
        ComboDimension.Items.Clear()
        Dim d As New dDimension
        Dim lista As New ArrayList
        lista = d.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each d In lista
                    ComboDimension.Items.Add(d)
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Id" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim oe As New dObjEspecifico
            id = row.Cells("Id").Value
            oe.ID = id
            oe = oe.buscar
            If Not oe Is Nothing Then
                TextId.Text = oe.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = oe.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                Dim og As dObjGral
                cargarcombotodos()
                For Each og In ComboObjGral.Items
                    If og.ID = oe.IDOBJGRAL Then
                        ComboObjGral.SelectedItem = og
                        Exit For
                    End If
                Next
                TextNombre.Text = oe.NOMBRE
                NumericAno.Value = oe.ANO
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "ObjGral" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim oe As New dObjEspecifico
            id = row.Cells("Id").Value
            oe.ID = id
            oe = oe.buscar
            If Not oe Is Nothing Then
                TextId.Text = oe.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = oe.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                Dim og As dObjGral
                cargarcombotodos()
                For Each og In ComboObjGral.Items
                    If og.ID = oe.IDOBJGRAL Then
                        ComboObjGral.SelectedItem = og
                        Exit For
                    End If
                Next
                TextNombre.Text = oe.NOMBRE
                NumericAno.Value = oe.ANO
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim oe As New dObjEspecifico
            id = row.Cells("Id").Value
            oe.ID = id
            oe = oe.buscar
            If Not oe Is Nothing Then
                TextId.Text = oe.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = oe.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                Dim og As dObjGral
                cargarcombotodos()
                For Each og In ComboObjGral.Items
                    If og.ID = oe.IDOBJGRAL Then
                        ComboObjGral.SelectedItem = og
                        Exit For
                    End If
                Next
                TextNombre.Text = oe.NOMBRE
                NumericAno.Value = oe.ANO
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Dimension" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim oe As New dObjEspecifico
            id = row.Cells("Id").Value
            oe.ID = id
            oe = oe.buscar
            If Not oe Is Nothing Then
                TextId.Text = oe.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = oe.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                Dim og As dObjGral
                cargarcombotodos()
                For Each og In ComboObjGral.Items
                    If og.ID = oe.IDOBJGRAL Then
                        ComboObjGral.SelectedItem = og
                        Exit For
                    End If
                Next
                TextNombre.Text = oe.NOMBRE
                NumericAno.Value = oe.ANO
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Año" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim oe As New dObjEspecifico
            id = row.Cells("Id").Value
            oe.ID = id
            oe = oe.buscar
            If Not oe Is Nothing Then
                TextId.Text = oe.ID
                Dim d As dDimension
                cargarcombotodos2()
                For Each d In ComboDimension.Items
                    If d.ID = oe.IDDIMENSION Then
                        ComboDimension.SelectedItem = d
                        Exit For
                    End If
                Next
                Dim og As dObjGral
                cargarcombotodos()
                For Each og In ComboObjGral.Items
                    If og.ID = oe.IDOBJGRAL Then
                        ComboObjGral.SelectedItem = og
                        Exit For
                    End If
                Next
                TextNombre.Text = oe.NOMBRE
                NumericAno.Value = oe.ANO
            End If
        End If
    End Sub

    Private Sub ComboDimension_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDimension.SelectedIndexChanged
        listarpordimension()
        ComboObjGral.Text = ""

        Dim dimension As dDimension = CType(ComboDimension.SelectedItem, dDimension)
        Dim iddimension As Integer = 0
        iddimension = dimension.ID

        Dim oe As New dObjEspecifico
        Dim lista As New ArrayList
        lista = oe.listarxdimension(iddimension)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.ColumnCount = 5
                DataGridView1.Columns(0).Name = "Id"
                DataGridView1.Columns(0).Width = 50
                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(1).Name = "Obj. Específico"
                DataGridView1.Columns(1).Width = 200
                DataGridView1.Columns(2).Name = "ObjGral"
                DataGridView1.Columns(2).HeaderText = "Obj. General"
                DataGridView1.Columns(2).Width = 200
                DataGridView1.Columns(3).Name = "Dimension"
                DataGridView1.Columns(3).HeaderText = "Dimensión"
                DataGridView1.Columns(3).Width = 100
                DataGridView1.Columns(4).Name = "Año"
                DataGridView1.Columns(4).Width = 50
                DataGridView1.Rows.Add(lista.Count)
                Dim og As New dObjGral
                Dim dimen As New dDimension
                For Each oe In lista
                    DataGridView1(columna, fila).Value = oe.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = oe.NOMBRE
                    columna = columna + 1
                    og.ID = oe.IDOBJGRAL
                    og = og.buscar
                    If Not og Is Nothing Then
                        DataGridView1(columna, fila).Value = og.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    dimen.ID = oe.IDDIMENSION
                    dimen = dimen.buscar
                    If Not dimen Is Nothing Then
                        DataGridView1(columna, fila).Value = dimen.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = oe.ANO
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(3), System.ComponentModel.ListSortDirection.Descending)
            End If
        End If
    End Sub
    Private Sub listarpordimension()
        Dim dimension As dDimension = CType(ComboDimension.SelectedItem, dDimension)
        Dim iddimension = dimension.ID
        ComboObjGral.Items.Clear()
        Dim og As New dObjGral
        Dim lista As New ArrayList
        lista = og.listarxdimension(iddimension)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each og In lista
                    ComboObjGral.Items.Add(og)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text.Length > 0 Then
            Dim oe As New dObjEspecifico
            Dim id As Long = CType(TextId.Text, Long)
            oe.ID = id
            If (oe.eliminar(Usuario)) Then
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

    Private Sub ComboObjGral_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboObjGral.SelectedIndexChanged
        Dim objetivog As dObjGral = CType(ComboObjGral.SelectedItem, dObjGral)
        Dim idobjetivog As Integer = 0
        idobjetivog = objetivog.ID

        Dim oe As New dObjEspecifico
        Dim lista As New ArrayList
        lista = oe.listarxobjgral(idobjetivog)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.ColumnCount = 5
                DataGridView1.Columns(0).Name = "Id"
                DataGridView1.Columns(0).Width = 50
                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(1).Name = "Obj. Específico"
                DataGridView1.Columns(1).Width = 200
                DataGridView1.Columns(2).Name = "ObjGral"
                DataGridView1.Columns(2).HeaderText = "Obj. General"
                DataGridView1.Columns(2).Width = 200
                DataGridView1.Columns(3).Name = "Dimension"
                DataGridView1.Columns(3).HeaderText = "Dimensión"
                DataGridView1.Columns(3).Width = 100
                DataGridView1.Columns(4).Name = "Año"
                DataGridView1.Columns(4).Width = 50
                DataGridView1.Rows.Add(lista.Count)
                Dim og As New dObjGral
                Dim dimen As New dDimension
                For Each oe In lista
                    DataGridView1(columna, fila).Value = oe.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = oe.NOMBRE
                    columna = columna + 1
                    og.ID = oe.IDOBJGRAL
                    og = og.buscar
                    If Not og Is Nothing Then
                        DataGridView1(columna, fila).Value = og.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    dimen.ID = oe.IDDIMENSION
                    dimen = dimen.buscar
                    If Not dimen Is Nothing Then
                        DataGridView1(columna, fila).Value = dimen.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = oe.ANO
                    columna = 0
                    fila = fila + 1
                Next
                DataGridView1.Sort(DataGridView1.Columns(3), System.ComponentModel.ListSortDirection.Descending)
            End If
        End If
    End Sub
End Class