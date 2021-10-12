Public Class FormComunicacionTecnica
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        RadioCliente.Checked = True
        cargartecnicoresponsable()
        cargarresponsableacciones()
        cargarLista()
        cargarLista2()
        limpiar()

    End Sub
    Public Sub cargartecnicoresponsable()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboTecnicoResp.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Public Sub cargarresponsableacciones()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboRespAcciones.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Public Sub cargarLista()
        Dim ctec As New dComunicacionTecnica
        Dim lista As New ArrayList
        lista = ctec.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ctec In lista
                    DataGridView1(columna, fila).Value = ctec.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ctec.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ctec.TIPOCLIENTE
                    columna = columna + 1
                    If ctec.TIPOCLIENTE = "c" Then
                        Dim pro As New dCliente
                        pro.ID = ctec.CLIENTE
                        pro = pro.buscar
                        If Not pro Is Nothing Then
                            DataGridView1(columna, fila).Value = pro.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                    Else
                        Dim tec As New dCliente
                        tec.ID = ctec.TECNICO
                        tec = tec.buscar
                        If Not tec Is Nothing Then
                            DataGridView1(columna, fila).Value = tec.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                    End If
                    DataGridView1(columna, fila).Value = ctec.DESCRIPCION
                    columna = columna + 1
                    Dim usu As New dUsuario
                    usu.ID = ctec.TECNICORESP
                    usu = usu.buscar
                    If Not usu Is Nothing Then
                        DataGridView1(columna, fila).Value = usu.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
      
    End Sub
    Public Sub cargarLista2()
        Dim ctec As New dComunicacionTecnica
        Dim lista As New ArrayList
        lista = ctec.listarfinalizados
        DataGridView2.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView2.Rows.Add(lista.Count)
                For Each ctec In lista
                    DataGridView2(columna, fila).Value = ctec.ID
                    columna = columna + 1
                    DataGridView2(columna, fila).Value = ctec.FECHA
                    columna = columna + 1
                    DataGridView2(columna, fila).Value = ctec.TIPOCLIENTE
                    columna = columna + 1
                    If ctec.TIPOCLIENTE = "c" Then
                        Dim pro As New dCliente
                        pro.ID = ctec.CLIENTE
                        pro = pro.buscar
                        If Not pro Is Nothing Then
                            DataGridView2(columna, fila).Value = pro.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView2(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                    Else
                        Dim tec As New dCliente
                        tec.ID = ctec.TECNICO
                        tec = tec.buscar
                        If Not tec Is Nothing Then
                            DataGridView2(columna, fila).Value = tec.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView2(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                    End If
                    DataGridView2(columna, fila).Value = ctec.DESCRIPCION
                    columna = columna + 1
                    Dim usu As New dUsuario
                    usu.ID = ctec.TECNICORESP
                    usu = usu.buscar
                    If Not usu Is Nothing Then
                        DataGridView2(columna, fila).Value = usu.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView2(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If

    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        DateFecha.Value = Now
        RadioCliente.Checked = True
        TextIdCliente.Text = ""
        TextNombreCliente.Text = ""
        TextIdTecnico.Text = ""
        TextNombreTecnico.Text = ""
        TextDescripcion.Text = ""
        ComboTecnicoResp.Text = ""
        TextAcciones.Text = ""
        ComboRespAcciones.Text = ""
        TextObservaciones.Text = ""

    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim tipo As String = ""
        If RadioCliente.Checked = True Then
            tipo = "c"
        Else
            tipo = "t"
        End If
        Dim cliente As Integer = 0
        Dim tecnico As Integer = 0
        If TextIdCliente.Text <> "" Then
            cliente = TextIdCliente.Text
        End If
        If TextIdTecnico.Text <> "" Then
            tecnico = TextIdTecnico.Text
        End If
        Dim descripcion As String = TextDescripcion.Text
        Dim idresponsable As dUsuario = CType(ComboTecnicoResp.SelectedItem, dUsuario)
        Dim responsable As Integer = 0
        If Not idresponsable Is Nothing Then
            responsable = idresponsable.ID
        End If
        Dim acciones As String = TextAcciones.Text
        Dim idrespacciones As dUsuario = CType(ComboRespAcciones.SelectedItem, dUsuario)
        Dim respacciones As Integer = 0
        If Not idrespacciones Is Nothing Then
            respacciones = idrespacciones.ID
        End If
        Dim observaciones As String = TextObservaciones.Text


        If TextId.Text.Trim.Length > 0 Then
            Dim ctec As New dComunicacionTecnica
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            ctec.ID = id
            ctec.FECHA = fec
            ctec.TIPOCLIENTE = tipo
            ctec.CLIENTE = cliente
            ctec.TECNICO = tecnico
            ctec.DESCRIPCION = descripcion
            ctec.TECNICORESP = responsable
            ctec.ACCIONES = acciones
            ctec.RESPACCIONES = respacciones
            ctec.OBSERVACIONES = observaciones
            If (ctec.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim ctec As New dComunicacionTecnica
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            ctec.FECHA = fec
            ctec.TIPOCLIENTE = tipo
            ctec.CLIENTE = cliente
            ctec.TECNICO = tecnico
            ctec.DESCRIPCION = descripcion
            ctec.TECNICORESP = responsable
            ctec.ACCIONES = acciones
            ctec.RESPACCIONES = respacciones
            ctec.OBSERVACIONES = observaciones
            If (ctec.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarLista()
        limpiar()
    End Sub

    
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ctec As New dComunicacionTecnica
            id = row.Cells("Id").Value
            ctec.ID = id
            ctec = ctec.buscar
            If Not ctec Is Nothing Then
                TextId.Text = ctec.ID
                DateFecha.Value = ctec.FECHA
                If ctec.TIPOCLIENTE = "c" Then
                    RadioCliente.Checked = True
                    habilitartextbox()
                    Dim pro As New dCliente
                    pro.ID = ctec.CLIENTE
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        TextIdCliente.Text = pro.ID
                        TextNombreCliente.Text = pro.NOMBRE
                    End If
                    pro = Nothing
                Else
                    RadioTecnico.Checked = True
                    habilitartextbox()
                    Dim tec As New dCliente
                    tec.ID = ctec.TECNICO
                    tec = tec.buscar
                    If Not tec Is Nothing Then
                        TextIdTecnico.Text = tec.ID
                        TextNombreTecnico.Text = tec.NOMBRE
                    End If
                    tec = Nothing
                End If
                TextDescripcion.Text = ctec.DESCRIPCION
                ComboTecnicoResp.SelectedItem = Nothing
                Dim tresp As dUsuario
                For Each tresp In ComboTecnicoResp.Items
                    If tresp.ID = ctec.TECNICORESP Then
                        ComboTecnicoResp.SelectedItem = tresp
                        Exit For
                    End If
                Next
                TextAcciones.Text = ctec.ACCIONES
                ComboRespAcciones.SelectedItem = Nothing
                Dim respacciones As dUsuario
                For Each respacciones In ComboRespAcciones.Items
                    If respacciones.ID = ctec.RESPACCIONES Then
                        ComboRespAcciones.SelectedItem = respacciones
                        Exit For
                    End If
                Next
                TextObservaciones.Text = ctec.OBSERVACIONES
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Tipo" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ctec As New dComunicacionTecnica
            id = row.Cells("Id").Value
            ctec.ID = id
            ctec = ctec.buscar
            If Not ctec Is Nothing Then
                TextId.Text = ctec.ID
                DateFecha.Value = ctec.FECHA
                If ctec.TIPOCLIENTE = "c" Then
                    RadioCliente.Checked = True
                    habilitartextbox()
                    Dim pro As New dCliente
                    pro.ID = ctec.CLIENTE
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        TextIdCliente.Text = pro.ID
                        TextNombreCliente.Text = pro.NOMBRE
                    End If
                Else
                    RadioTecnico.Checked = True
                    habilitartextbox()
                    Dim tec As New dCliente
                    tec.ID = ctec.TECNICO
                    tec = tec.buscar
                    If Not tec Is Nothing Then
                        TextIdTecnico.Text = tec.ID
                        TextNombreTecnico.Text = tec.NOMBRE
                    End If
                End If
                TextDescripcion.Text = ctec.DESCRIPCION
                ComboTecnicoResp.SelectedItem = Nothing
                Dim tresp As dUsuario
                For Each tresp In ComboTecnicoResp.Items
                    If tresp.ID = ctec.TECNICORESP Then
                        ComboTecnicoResp.SelectedItem = tresp
                        Exit For
                    End If
                Next
                TextAcciones.Text = ctec.ACCIONES
                ComboRespAcciones.SelectedItem = Nothing
                Dim respacciones As dUsuario
                For Each respacciones In ComboRespAcciones.Items
                    If respacciones.ID = ctec.RESPACCIONES Then
                        ComboRespAcciones.SelectedItem = respacciones
                        Exit For
                    End If
                Next
                TextObservaciones.Text = ctec.OBSERVACIONES
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ctec As New dComunicacionTecnica
            id = row.Cells("Id").Value
            ctec.ID = id
            ctec = ctec.buscar
            If Not ctec Is Nothing Then
                TextId.Text = ctec.ID
                DateFecha.Value = ctec.FECHA
                If ctec.TIPOCLIENTE = "c" Then
                    RadioCliente.Checked = True
                    habilitartextbox()
                    Dim pro As New dCliente
                    pro.ID = ctec.CLIENTE
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        TextIdCliente.Text = pro.ID
                        TextNombreCliente.Text = pro.NOMBRE
                    End If
                Else
                    RadioTecnico.Checked = True
                    habilitartextbox()
                    Dim tec As New dCliente
                    tec.ID = ctec.TECNICO
                    tec = tec.buscar
                    If Not tec Is Nothing Then
                        TextIdTecnico.Text = tec.ID
                        TextNombreTecnico.Text = tec.NOMBRE
                    End If
                End If
                TextDescripcion.Text = ctec.DESCRIPCION
                ComboTecnicoResp.SelectedItem = Nothing
                Dim tresp As dUsuario
                For Each tresp In ComboTecnicoResp.Items
                    If tresp.ID = ctec.TECNICORESP Then
                        ComboTecnicoResp.SelectedItem = tresp
                        Exit For
                    End If
                Next
                TextAcciones.Text = ctec.ACCIONES
                ComboRespAcciones.SelectedItem = Nothing
                Dim respacciones As dUsuario
                For Each respacciones In ComboRespAcciones.Items
                    If respacciones.ID = ctec.RESPACCIONES Then
                        ComboRespAcciones.SelectedItem = respacciones
                        Exit For
                    End If
                Next
                TextObservaciones.Text = ctec.OBSERVACIONES
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Descripcion" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ctec As New dComunicacionTecnica
            id = row.Cells("Id").Value
            ctec.ID = id
            ctec = ctec.buscar
            If Not ctec Is Nothing Then
                TextId.Text = ctec.ID
                DateFecha.Value = ctec.FECHA
                If ctec.TIPOCLIENTE = "c" Then
                    RadioCliente.Checked = True
                    habilitartextbox()
                    Dim pro As New dCliente
                    pro.ID = ctec.CLIENTE
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        TextIdCliente.Text = pro.ID
                        TextNombreCliente.Text = pro.NOMBRE
                    End If
                Else
                    RadioTecnico.Checked = True
                    habilitartextbox()
                    Dim tec As New dCliente
                    tec.ID = ctec.TECNICO
                    tec = tec.buscar
                    If Not tec Is Nothing Then
                        TextIdTecnico.Text = tec.ID
                        TextNombreTecnico.Text = tec.NOMBRE
                    End If
                End If
                TextDescripcion.Text = ctec.DESCRIPCION
                ComboTecnicoResp.SelectedItem = Nothing
                Dim tresp As dUsuario
                For Each tresp In ComboTecnicoResp.Items
                    If tresp.ID = ctec.TECNICORESP Then
                        ComboTecnicoResp.SelectedItem = tresp
                        Exit For
                    End If
                Next
                TextAcciones.Text = ctec.ACCIONES
                ComboRespAcciones.SelectedItem = Nothing
                Dim respacciones As dUsuario
                For Each respacciones In ComboRespAcciones.Items
                    If respacciones.ID = ctec.RESPACCIONES Then
                        ComboRespAcciones.SelectedItem = respacciones
                        Exit For
                    End If
                Next
                TextObservaciones.Text = ctec.OBSERVACIONES
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Responsable" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ctec As New dComunicacionTecnica
            id = row.Cells("Id").Value
            ctec.ID = id
            ctec = ctec.buscar
            If Not ctec Is Nothing Then
                TextId.Text = ctec.ID
                DateFecha.Value = ctec.FECHA
                If ctec.TIPOCLIENTE = "c" Then
                    RadioCliente.Checked = True
                    habilitartextbox()
                    Dim pro As New dCliente
                    pro.ID = ctec.CLIENTE
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        TextIdCliente.Text = pro.ID
                        TextNombreCliente.Text = pro.NOMBRE
                    End If
                Else
                    RadioTecnico.Checked = True
                    habilitartextbox()
                    Dim tec As New dCliente
                    tec.ID = ctec.TECNICO
                    tec = tec.buscar
                    If Not tec Is Nothing Then
                        TextIdTecnico.Text = tec.ID
                        TextNombreTecnico.Text = tec.NOMBRE
                    End If
                End If
                TextDescripcion.Text = ctec.DESCRIPCION
                ComboTecnicoResp.SelectedItem = Nothing
                Dim tresp As dUsuario
                For Each tresp In ComboTecnicoResp.Items
                    If tresp.ID = ctec.TECNICORESP Then
                        ComboTecnicoResp.SelectedItem = tresp
                        Exit For
                    End If
                Next
                TextAcciones.Text = ctec.ACCIONES
                ComboRespAcciones.SelectedItem = Nothing
                Dim respacciones As dUsuario
                For Each respacciones In ComboRespAcciones.Items
                    If respacciones.ID = ctec.RESPACCIONES Then
                        ComboRespAcciones.SelectedItem = respacciones
                        Exit For
                    End If
                Next
                TextObservaciones.Text = ctec.OBSERVACIONES
            End If
        End If
    End Sub

    Private Sub ButtonBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarCliente.Click
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            TextIdCliente.Text = cli.ID
            TextNombreCliente.Text = cli.NOMBRE
            TextDescripcion.Focus()
        End If
    End Sub

    Private Sub ButtonBuscarTecnico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarTecnico.Click
        'Dim v As New FormBuscarTecnico
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim tec As dCliente = v.Cliente
            TextIdTecnico.Text = tec.ID
            TextNombreTecnico.Text = tec.NOMBRE
            TextDescripcion.Focus()
        End If
    End Sub

    Private Sub RadioCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCliente.CheckedChanged
        habilitartextbox()
    End Sub
    Private Sub habilitartextbox()
        If RadioCliente.Checked = True Then
            TextIdCliente.Enabled = True
            TextNombreCliente.Enabled = True
            ButtonBuscarCliente.Enabled = True
            TextIdTecnico.Enabled = False
            TextNombreTecnico.Enabled = False
            ButtonBuscarTecnico.Enabled = False
        Else
            TextIdCliente.Enabled = False
            TextNombreCliente.Enabled = False
            ButtonBuscarCliente.Enabled = False
            TextIdTecnico.Enabled = True
            TextNombreTecnico.Enabled = True
            ButtonBuscarTecnico.Enabled = True
        End If
    End Sub

    Private Sub ButtonFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFinalizar.Click
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim tipo As String = ""
        If RadioCliente.Checked = True Then
            tipo = "c"
        Else
            tipo = "t"
        End If
        Dim cliente As Integer = 0
        Dim tecnico As Integer = 0
        If TextIdCliente.Text <> "" Then
            cliente = TextIdCliente.Text
        End If
        If TextIdTecnico.Text <> "" Then
            tecnico = TextIdTecnico.Text
        End If
        Dim descripcion As String = TextDescripcion.Text
        Dim idresponsable As dUsuario = CType(ComboTecnicoResp.SelectedItem, dUsuario)
        Dim responsable As Integer = 0
        If Not idresponsable Is Nothing Then
            responsable = idresponsable.ID
        End If
        Dim acciones As String = TextAcciones.Text
        Dim idrespacciones As dUsuario = CType(ComboRespAcciones.SelectedItem, dUsuario)
        Dim respacciones As Integer = 0
        If Not idrespacciones Is Nothing Then
            respacciones = idrespacciones.ID
        End If
        Dim observaciones As String = TextObservaciones.Text


        If TextId.Text.Trim.Length > 0 Then
            Dim ctec As New dComunicacionTecnica
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            ctec.ID = id
            ctec.FECHA = fec
            ctec.TIPOCLIENTE = tipo
            ctec.CLIENTE = cliente
            ctec.TECNICO = tecnico
            ctec.DESCRIPCION = descripcion
            ctec.TECNICORESP = responsable
            ctec.ACCIONES = acciones
            ctec.RESPACCIONES = respacciones
            ctec.OBSERVACIONES = observaciones
            If (ctec.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                ctec.marcarvisto(Usuario)
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim ctec As New dComunicacionTecnica
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            ctec.FECHA = fec
            ctec.TIPOCLIENTE = tipo
            ctec.CLIENTE = cliente
            ctec.TECNICO = tecnico
            ctec.DESCRIPCION = descripcion
            ctec.TECNICORESP = responsable
            ctec.ACCIONES = acciones
            ctec.RESPACCIONES = respacciones
            ctec.OBSERVACIONES = observaciones
            If (ctec.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                ctec.marcarvisto(Usuario)
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarLista()
        limpiar()
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If DataGridView2.Columns(e.ColumnIndex).Name = "Fecha2" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ctec As New dComunicacionTecnica
            id = row.Cells("Id2").Value
            ctec.ID = id
            ctec = ctec.buscar
            If Not ctec Is Nothing Then
                TextId.Text = ctec.ID
                DateFecha.Value = ctec.FECHA
                If ctec.TIPOCLIENTE = "c" Then
                    RadioCliente.Checked = True
                    habilitartextbox()
                    Dim pro As New dCliente
                    pro.ID = ctec.CLIENTE
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        TextIdCliente.Text = pro.ID
                        TextNombreCliente.Text = pro.NOMBRE
                    End If
                    pro = Nothing
                Else
                    RadioTecnico.Checked = True
                    habilitartextbox()
                    Dim tec As New dCliente
                    tec.ID = ctec.TECNICO
                    tec = tec.buscar
                    If Not tec Is Nothing Then
                        TextIdTecnico.Text = tec.ID
                        TextNombreTecnico.Text = tec.NOMBRE
                    End If
                    tec = Nothing
                End If
                TextDescripcion.Text = ctec.DESCRIPCION
                ComboTecnicoResp.SelectedItem = Nothing
                Dim tresp As dUsuario
                For Each tresp In ComboTecnicoResp.Items
                    If tresp.ID = ctec.TECNICORESP Then
                        ComboTecnicoResp.SelectedItem = tresp
                        Exit For
                    End If
                Next
                TextAcciones.Text = ctec.ACCIONES
                ComboRespAcciones.SelectedItem = Nothing
                Dim respacciones As dUsuario
                For Each respacciones In ComboRespAcciones.Items
                    If respacciones.ID = ctec.RESPACCIONES Then
                        ComboRespAcciones.SelectedItem = respacciones
                        Exit For
                    End If
                Next
                TextObservaciones.Text = ctec.OBSERVACIONES
            End If
        End If
        If DataGridView2.Columns(e.ColumnIndex).Name = "Tipo2" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ctec As New dComunicacionTecnica
            id = row.Cells("Id2").Value
            ctec.ID = id
            ctec = ctec.buscar
            If Not ctec Is Nothing Then
                TextId.Text = ctec.ID
                DateFecha.Value = ctec.FECHA
                If ctec.TIPOCLIENTE = "c" Then
                    RadioCliente.Checked = True
                    habilitartextbox()
                    Dim pro As New dCliente
                    pro.ID = ctec.CLIENTE
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        TextIdCliente.Text = pro.ID
                        TextNombreCliente.Text = pro.NOMBRE
                    End If
                Else
                    RadioTecnico.Checked = True
                    habilitartextbox()
                    Dim tec As New dCliente
                    tec.ID = ctec.TECNICO
                    tec = tec.buscar
                    If Not tec Is Nothing Then
                        TextIdTecnico.Text = tec.ID
                        TextNombreTecnico.Text = tec.NOMBRE
                    End If
                End If
                TextDescripcion.Text = ctec.DESCRIPCION
                ComboTecnicoResp.SelectedItem = Nothing
                Dim tresp As dUsuario
                For Each tresp In ComboTecnicoResp.Items
                    If tresp.ID = ctec.TECNICORESP Then
                        ComboTecnicoResp.SelectedItem = tresp
                        Exit For
                    End If
                Next
                TextAcciones.Text = ctec.ACCIONES
                ComboRespAcciones.SelectedItem = Nothing
                Dim respacciones As dUsuario
                For Each respacciones In ComboRespAcciones.Items
                    If respacciones.ID = ctec.RESPACCIONES Then
                        ComboRespAcciones.SelectedItem = respacciones
                        Exit For
                    End If
                Next
                TextObservaciones.Text = ctec.OBSERVACIONES
            End If
        End If
        If DataGridView2.Columns(e.ColumnIndex).Name = "Nombre2" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ctec As New dComunicacionTecnica
            id = row.Cells("Id2").Value
            ctec.ID = id
            ctec = ctec.buscar
            If Not ctec Is Nothing Then
                TextId.Text = ctec.ID
                DateFecha.Value = ctec.FECHA
                If ctec.TIPOCLIENTE = "c" Then
                    RadioCliente.Checked = True
                    habilitartextbox()
                    Dim pro As New dCliente
                    pro.ID = ctec.CLIENTE
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        TextIdCliente.Text = pro.ID
                        TextNombreCliente.Text = pro.NOMBRE
                    End If
                Else
                    RadioTecnico.Checked = True
                    habilitartextbox()
                    Dim tec As New dCliente
                    tec.ID = ctec.TECNICO
                    tec = tec.buscar
                    If Not tec Is Nothing Then
                        TextIdTecnico.Text = tec.ID
                        TextNombreTecnico.Text = tec.NOMBRE
                    End If
                End If
                TextDescripcion.Text = ctec.DESCRIPCION
                ComboTecnicoResp.SelectedItem = Nothing
                Dim tresp As dUsuario
                For Each tresp In ComboTecnicoResp.Items
                    If tresp.ID = ctec.TECNICORESP Then
                        ComboTecnicoResp.SelectedItem = tresp
                        Exit For
                    End If
                Next
                TextAcciones.Text = ctec.ACCIONES
                ComboRespAcciones.SelectedItem = Nothing
                Dim respacciones As dUsuario
                For Each respacciones In ComboRespAcciones.Items
                    If respacciones.ID = ctec.RESPACCIONES Then
                        ComboRespAcciones.SelectedItem = respacciones
                        Exit For
                    End If
                Next
                TextObservaciones.Text = ctec.OBSERVACIONES
            End If
        End If
        If DataGridView2.Columns(e.ColumnIndex).Name = "Descripcion2" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ctec As New dComunicacionTecnica
            id = row.Cells("Id2").Value
            ctec.ID = id
            ctec = ctec.buscar
            If Not ctec Is Nothing Then
                TextId.Text = ctec.ID
                DateFecha.Value = ctec.FECHA
                If ctec.TIPOCLIENTE = "c" Then
                    RadioCliente.Checked = True
                    habilitartextbox()
                    Dim pro As New dCliente
                    pro.ID = ctec.CLIENTE
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        TextIdCliente.Text = pro.ID
                        TextNombreCliente.Text = pro.NOMBRE
                    End If
                Else
                    RadioTecnico.Checked = True
                    habilitartextbox()
                    Dim tec As New dCliente
                    tec.ID = ctec.TECNICO
                    tec = tec.buscar
                    If Not tec Is Nothing Then
                        TextIdTecnico.Text = tec.ID
                        TextNombreTecnico.Text = tec.NOMBRE
                    End If
                End If
                TextDescripcion.Text = ctec.DESCRIPCION
                ComboTecnicoResp.SelectedItem = Nothing
                Dim tresp As dUsuario
                For Each tresp In ComboTecnicoResp.Items
                    If tresp.ID = ctec.TECNICORESP Then
                        ComboTecnicoResp.SelectedItem = tresp
                        Exit For
                    End If
                Next
                TextAcciones.Text = ctec.ACCIONES
                ComboRespAcciones.SelectedItem = Nothing
                Dim respacciones As dUsuario
                For Each respacciones In ComboRespAcciones.Items
                    If respacciones.ID = ctec.RESPACCIONES Then
                        ComboRespAcciones.SelectedItem = respacciones
                        Exit For
                    End If
                Next
                TextObservaciones.Text = ctec.OBSERVACIONES
            End If
        End If
        If DataGridView2.Columns(e.ColumnIndex).Name = "Responsable2" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ctec As New dComunicacionTecnica
            id = row.Cells("Id2").Value
            ctec.ID = id
            ctec = ctec.buscar
            If Not ctec Is Nothing Then
                TextId.Text = ctec.ID
                DateFecha.Value = ctec.FECHA
                If ctec.TIPOCLIENTE = "c" Then
                    RadioCliente.Checked = True
                    habilitartextbox()
                    Dim pro As New dCliente
                    pro.ID = ctec.CLIENTE
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        TextIdCliente.Text = pro.ID
                        TextNombreCliente.Text = pro.NOMBRE
                    End If
                Else
                    RadioTecnico.Checked = True
                    habilitartextbox()
                    Dim tec As New dCliente
                    tec.ID = ctec.TECNICO
                    tec = tec.buscar
                    If Not tec Is Nothing Then
                        TextIdTecnico.Text = tec.ID
                        TextNombreTecnico.Text = tec.NOMBRE
                    End If
                End If
                TextDescripcion.Text = ctec.DESCRIPCION
                ComboTecnicoResp.SelectedItem = Nothing
                Dim tresp As dUsuario
                For Each tresp In ComboTecnicoResp.Items
                    If tresp.ID = ctec.TECNICORESP Then
                        ComboTecnicoResp.SelectedItem = tresp
                        Exit For
                    End If
                Next
                TextAcciones.Text = ctec.ACCIONES
                ComboRespAcciones.SelectedItem = Nothing
                Dim respacciones As dUsuario
                For Each respacciones In ComboRespAcciones.Items
                    If respacciones.ID = ctec.RESPACCIONES Then
                        ComboRespAcciones.SelectedItem = respacciones
                        Exit For
                    End If
                Next
                TextObservaciones.Text = ctec.OBSERVACIONES
            End If
        End If
    End Sub
End Class