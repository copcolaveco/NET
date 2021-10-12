Public Class FormListaDePrecios
    Private tipo As Integer = 0
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
        cargarComboTI()
        cargarComboFiltro()
        cargarComboTC()
        cargarLista()
        cargarLista2()
        limpiar()
    End Sub
#End Region
    Private Sub limpiar()
        TextId.Text = ""
        TextCodigo.Text = ""
        TextDescripcion.Text = ""
        TextPrecio1.Text = ""
        TextPrecio2.Text = ""
        TextPrecio3.Text = ""
        TextPrecio4.Text = ""
        TextPrecio5.Text = ""
        TextPrecio6.Text = ""
        TextPrecio7.Text = ""
        ComboTI.SelectedItem = Nothing
        ComboTI.Text = ""
        TextDescTecnica.Text = ""
        TextAbreviatura.Text = ""
        TextOrden.Text = ""
        ComboTipoControl.SelectedItem = Nothing
        ComboTipoControl.Text = ""
        ComboResultados.Text = ""
        CheckOcultar.Checked = False
        CheckPaquete.Checked = False
        CheckAcreditado.Checked = False
        ListOpciones.Items.Clear()
        TextCodigo.Focus()
    End Sub
    Public Sub cargarComboTI()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    ComboTI.Items.Add(ti)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboFiltro()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    ComboFiltro.Items.Add(ti)
                    ComboFiltro2.Items.Add(ti)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboTC()
        Dim tc As New dTipoControl
        Dim lista As New ArrayList
        lista = tc.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each tc In lista
                    ComboTipoControl.Items.Add(tc)
                Next
            End If
        End If
    End Sub
    Public Sub cargarLista()
        Dim l As New dListaPrecios
        Dim id As Long
        Dim codigo As String
        Dim descripcion As String
        Dim precio1 As Double
        Dim precio2 As Double
        Dim precio3 As Double
        Dim precio4 As Double
        Dim precio5 As Double
        Dim precio6 As Double
        Dim precio7 As Double
        Dim tinf As Integer
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = l.listar
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add(lista.Count)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each l In lista
                    If l.PAQUETE = 1 Then
                        id = l.ID
                        codigo = l.CODIGO
                        descripcion = l.DESCRIPCION
                        precio1 = l.PRECIO1
                        precio2 = l.PRECIO2
                        precio3 = l.PRECIO3
                        precio4 = l.PRECIO4
                        precio5 = l.PRECIO5
                        precio6 = l.PRECIO6
                        precio7 = l.PRECIO7
                        tinf = l.TI
                        DataGridView1(columna, fila).Value = id
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = codigo
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = descripcion
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        Dim ti As New dTipoInforme
                        ti.ID = tinf
                        ti = ti.buscar
                        If Not ti Is Nothing Then
                            DataGridView1(columna, fila).Value = ti.NOMBRE
                            DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio1
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio2
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio3
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio4
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio5
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio6
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio7
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = 0
                        fila = fila + 1
                    Else
                        id = l.ID
                        codigo = l.CODIGO
                        descripcion = l.DESCRIPCION
                        precio1 = l.PRECIO1
                        precio2 = l.PRECIO2
                        precio3 = l.PRECIO3
                        precio4 = l.PRECIO4
                        precio5 = l.PRECIO5
                        precio6 = l.PRECIO6
                        precio7 = l.PRECIO7
                        tinf = l.TI
                        DataGridView1(columna, fila).Value = id
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = codigo
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = descripcion
                        columna = columna + 1
                        Dim ti As New dTipoInforme
                        ti.ID = tinf
                        ti = ti.buscar
                        If Not ti Is Nothing Then
                            DataGridView1(columna, fila).Value = ti.NOMBRE
                        End If
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio1
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio2
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio3
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio4
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio5
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio6
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio7
                        columna = 0
                        fila = fila + 1
                    End If
                    
                Next
            End If
        End If
    End Sub
    Public Sub cargarLista2()
        Dim l As New dListaPrecios
        Dim id As Long
        Dim codigo As String
        Dim desctecnica As String
        Dim tinf As Integer
        Dim abreviatura As String
        Dim orden As Integer
        Dim tcontrol As Integer
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = l.listar
        DataGridView2.Rows.Clear()
        DataGridView2.Rows.Add(lista.Count)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each l In lista
                    If l.PAQUETE = 1 Then
                        id = l.ID
                        codigo = l.CODIGO
                        desctecnica = l.DESCTECNICA
                        tinf = l.TI
                        abreviatura = l.ABREVIATURA
                        orden = l.ORDEN
                        tcontrol = l.TIPOCONTROL
                        DataGridView2(columna, fila).Value = id
                        DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = codigo
                        DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = desctecnica
                        DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = abreviatura
                        DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = orden
                        DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        Dim ti As New dTipoInforme
                        ti.ID = tinf
                        ti = ti.buscar
                        If Not ti Is Nothing Then
                            DataGridView2(columna, fila).Value = ti.NOMBRE
                            DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        columna = columna + 1
                        Dim tc As New dTipoControl
                        tc.ID = tcontrol
                        tc = tc.buscar
                        If Not tc Is Nothing Then
                            DataGridView2(columna, fila).Value = tc.NOMBRE
                            DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        columna = 0
                        fila = fila + 1
                    Else
                        id = l.ID
                        codigo = l.CODIGO
                        desctecnica = l.DESCTECNICA
                        tinf = l.TI
                        abreviatura = l.ABREVIATURA
                        orden = l.ORDEN
                        tcontrol = l.TIPOCONTROL
                        DataGridView2(columna, fila).Value = id
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = codigo
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = desctecnica
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = abreviatura
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = orden
                        columna = columna + 1
                        Dim ti As New dTipoInforme
                        ti.ID = tinf
                        ti = ti.buscar
                        If Not ti Is Nothing Then
                            DataGridView2(columna, fila).Value = ti.NOMBRE
                        End If
                        columna = columna + 1
                        Dim tc As New dTipoControl
                        tc.ID = tcontrol
                        tc = tc.buscar
                        If Not tc Is Nothing Then
                            DataGridView2(columna, fila).Value = tc.NOMBRE
                        End If
                        columna = 0
                        fila = fila + 1
                    End If
                   
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim lp As New dListaPrecios
        Dim id As Long = 0
        If DataGridView1.Columns(e.ColumnIndex).Name = "Codigo" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            id = row.Cells("Id").Value
            lp.ID = id
            lp = lp.buscar
            If Not lp Is Nothing Then
                TextId.Text = lp.ID
                TextCodigo.Text = lp.CODIGO
                TextDescripcion.Text = lp.DESCRIPCION
                TextPrecio1.Text = lp.PRECIO1
                TextPrecio2.Text = lp.PRECIO2
                TextPrecio3.Text = lp.PRECIO3
                TextPrecio4.Text = lp.PRECIO4
                TextPrecio5.Text = lp.PRECIO5
                TextPrecio6.Text = lp.PRECIO6
                TextPrecio7.Text = lp.PRECIO5
                Dim ti As dTipoInforme
                For Each ti In ComboTI.Items
                    If ti.ID = lp.TI Then
                        ComboTI.SelectedItem = ti
                        Exit For
                    Else
                        ComboTI.SelectedItem = Nothing
                        ComboTI.Text = ""
                    End If
                Next
                TextDescTecnica.Text = lp.DESCTECNICA
                TextAbreviatura.Text = lp.ABREVIATURA
                If lp.ACREDITADO = 1 Then
                    CheckAcreditado.Checked = True
                Else
                    CheckAcreditado.Checked = False
                End If
                If lp.MOSTRAR_R = 0 Then
                    ComboResultados.Text = "Ninguno"
                ElseIf lp.MOSTRAR_R = 1 Then
                    ComboResultados.Text = "Resultado 1"
                ElseIf lp.MOSTRAR_R = 2 Then
                    ComboResultados.Text = "Resultado 2"
                ElseIf lp.MOSTRAR_R = 3 Then
                    ComboResultados.Text = "Resultado 1 y 2"
                End If
                TextOrden.Text = lp.ORDEN
                Dim tc As dTipoControl
                For Each tc In ComboTipoControl.Items
                    If tc.ID = lp.TIPOCONTROL Then
                        ComboTipoControl.SelectedItem = tc
                        Exit For
                    Else
                        ComboTipoControl.SelectedItem = Nothing
                        ComboTipoControl.Text = ""
                    End If
                Next
                If lp.OCULTAR = 1 Then
                    CheckOcultar.Checked = True
                Else
                    CheckOcultar.Checked = False
                End If
                If lp.PAQUETE = 1 Then
                    CheckPaquete.Checked = True
                Else
                    CheckPaquete.Checked = False
                End If
                listaropciones()
            End If
            TextCodigo.Focus()
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Descripcion" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            id = row.Cells("Id").Value
            lp.ID = id
            lp = lp.buscar
            If Not lp Is Nothing Then
                TextId.Text = lp.ID
                TextCodigo.Text = lp.CODIGO
                TextDescripcion.Text = lp.DESCRIPCION
                TextPrecio1.Text = lp.PRECIO1
                TextPrecio2.Text = lp.PRECIO2
                TextPrecio3.Text = lp.PRECIO3
                TextPrecio4.Text = lp.PRECIO4
                TextPrecio5.Text = lp.PRECIO5
                TextPrecio6.Text = lp.PRECIO6
                TextPrecio7.Text = lp.PRECIO5
                Dim ti As dTipoInforme
                For Each ti In ComboTI.Items
                    If ti.ID = lp.TI Then
                        ComboTI.SelectedItem = ti
                        Exit For
                    Else
                        ComboTI.SelectedItem = Nothing
                        ComboTI.Text = ""
                    End If
                Next
                TextDescTecnica.Text = lp.DESCTECNICA
                TextAbreviatura.Text = lp.ABREVIATURA
                If lp.ACREDITADO = 1 Then
                    CheckAcreditado.Checked = True
                Else
                    CheckAcreditado.Checked = False
                End If
                If lp.MOSTRAR_R = 0 Then
                    ComboResultados.Text = "Ninguno"
                ElseIf lp.MOSTRAR_R = 1 Then
                    ComboResultados.Text = "Resultado 1"
                ElseIf lp.MOSTRAR_R = 2 Then
                    ComboResultados.Text = "Resultado 2"
                ElseIf lp.MOSTRAR_R = 3 Then
                    ComboResultados.Text = "Resultado 1 y 2"
                End If
                TextOrden.Text = lp.ORDEN
                Dim tc As dTipoControl
                For Each tc In ComboTipoControl.Items
                    If tc.ID = lp.TIPOCONTROL Then
                        ComboTipoControl.SelectedItem = tc
                        Exit For
                    Else
                        ComboTipoControl.SelectedItem = Nothing
                        ComboTipoControl.Text = ""
                    End If
                Next
                If lp.OCULTAR = 1 Then
                    CheckOcultar.Checked = True
                Else
                    CheckOcultar.Checked = False
                End If
                If lp.PAQUETE = 1 Then
                    CheckPaquete.Checked = True
                Else
                    CheckPaquete.Checked = False
                End If
                listaropciones()
            End If
            TextCodigo.Focus()
        End If
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
       
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        cargarLista()
        cargarLista2()
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim codigo As String = TextCodigo.Text.Trim
        Dim paquete As Integer = 0
        If CheckPaquete.Checked = True Then
            paquete = 1
        Else
            paquete = 0
        End If
        Dim descripcion As String = TextDescripcion.Text.Trim
        Dim precio1 As Double = 0
        If TextPrecio1.Text <> "" Then
            precio1 = TextPrecio1.Text.Trim
        End If
        Dim precio2 As Double = 0
        If TextPrecio2.Text <> "" Then
            precio2 = TextPrecio2.Text.Trim
        End If
        Dim precio3 As Double = 0
        If TextPrecio3.Text <> "" Then
            precio3 = TextPrecio3.Text.Trim
        End If
        Dim precio4 As Double = 0
        If TextPrecio4.Text <> "" Then
            precio4 = TextPrecio4.Text.Trim
        End If
        Dim precio5 As Double = 0
        If TextPrecio5.Text <> "" Then
            precio5 = TextPrecio5.Text.Trim
        End If
        Dim precio6 As Double = 0
        If TextPrecio6.Text <> "" Then
            precio6 = TextPrecio6.Text.Trim
        End If
        Dim precio7 As Double = 0
        If TextPrecio7.Text <> "" Then
            precio7 = TextPrecio7.Text.Trim
        End If
        Dim idtipoinforme As dTipoInforme = CType(ComboTI.SelectedItem, dTipoInforme)
        Dim ti As Integer = 0
        If Not idtipoinforme Is Nothing Then
            ti = idtipoinforme.ID
        End If
        Dim desctecnica As String = ""
        If TextDescTecnica.Text <> "" Then
            desctecnica = TextDescTecnica.Text.Trim
        Else
            desctecnica = TextDescripcion.Text.Trim
        End If
        Dim idtipocontrol As dTipoControl = CType(ComboTipoControl.SelectedItem, dTipoControl)
        Dim tc As Integer = 0
        If Not idtipocontrol Is Nothing Then
            tc = idtipocontrol.ID
        End If
        Dim abreviatura As String = ""
        If TextAbreviatura.Text <> "" Then
            abreviatura = TextAbreviatura.Text.Trim
        Else
            abreviatura = ""
        End If
        Dim acreditado As Integer = 0
        If CheckAcreditado.Checked = True Then
            acreditado = 1
        Else
            acreditado = 0
        End If
        Dim resultado As Integer = 0
        If ComboResultados.Text = "Ninguno" Then
            resultado = 0
        ElseIf ComboResultados.Text = "Resultado 1" Then
            resultado = 1
        ElseIf ComboResultados.Text = "Resultado 2" Then
            resultado = 2
        ElseIf ComboResultados.Text = "Resultado 1 y 2" Then
            resultado = 3
        End If
        Dim orden As Integer = 0
        If TextOrden.Text <> "" Then
            orden = TextOrden.Text
        End If
        Dim ocultar As Integer = 0
        If CheckOcultar.Checked = True Then
            ocultar = 1
        End If
        If Not DataGridView1.SelectedColumns Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextDescripcion.Text.Trim.Length > 0 Then
                Dim lp As New dListaPrecios()
                Dim id As Long = TextId.Text.Trim
                lp.ID = id
                lp.CODIGO = codigo
                lp.DESCRIPCION = descripcion
                lp.PRECIO1 = precio1
                lp.PRECIO2 = precio2
                lp.PRECIO3 = precio3
                lp.PRECIO4 = precio4
                lp.PRECIO5 = precio5
                lp.PRECIO6 = precio6
                lp.PRECIO7 = precio7
                lp.TI = ti
                lp.DESCTECNICA = desctecnica
                lp.TIPOCONTROL = tc
                lp.ABREVIATURA = abreviatura
                lp.ACREDITADO = acreditado
                lp.ORDEN = orden
                lp.OCULTAR = ocultar
                lp.PAQUETE = paquete
                lp.MOSTRAR_R = resultado
                If (lp.modificar(Usuario)) Then
                    MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextDescripcion.Text.Trim.Length > 0 Then
                Dim lp As New dListaPrecios()
                lp.CODIGO = codigo
                lp.DESCRIPCION = descripcion
                lp.PRECIO1 = precio1
                lp.PRECIO2 = precio2
                lp.PRECIO3 = precio3
                lp.PRECIO4 = precio4
                lp.PRECIO5 = precio5
                lp.PRECIO6 = precio6
                lp.PRECIO7 = precio7
                lp.TI = ti
                lp.DESCTECNICA = desctecnica
                lp.TIPOCONTROL = tc
                lp.ABREVIATURA = abreviatura
                lp.ACREDITADO = acreditado
                lp.ORDEN = orden
                lp.OCULTAR = ocultar
                lp.PAQUETE = paquete
                lp.MOSTRAR_R = resultado
                If (lp.guardar(Usuario)) Then
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                    MsgBox("Dar de alta en el sistema de gestión", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        If ComboFiltro.Text <> "" Or ComboFiltro2.Text <> "" Then
            cargarxtipo()
            cargarxtipo2()
        Else
            cargarLista()
            cargarLista2()
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        cargarLista()
        cargarLista2()
        limpiar()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        guardar()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click

    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Dim lp As New dListaPrecios
        Dim id As Long = 0
        If DataGridView2.Columns(e.ColumnIndex).Name = "Codigo2" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            id = row.Cells("Id2").Value
            lp.ID = id
            lp = lp.buscar
            If Not lp Is Nothing Then
                TextId.Text = lp.ID
                TextCodigo.Text = lp.CODIGO
                TextDescripcion.Text = lp.DESCRIPCION
                TextPrecio1.Text = lp.PRECIO1
                TextPrecio2.Text = lp.PRECIO2
                TextPrecio3.Text = lp.PRECIO3
                TextPrecio4.Text = lp.PRECIO4
                TextPrecio5.Text = lp.PRECIO5
                TextPrecio6.Text = lp.PRECIO6
                TextPrecio7.Text = lp.PRECIO5
                Dim ti As dTipoInforme
                For Each ti In ComboTI.Items
                    If ti.ID = lp.TI Then
                        ComboTI.SelectedItem = ti
                        Exit For
                    Else
                        ComboTI.SelectedItem = Nothing
                        ComboTI.Text = ""
                    End If
                Next
                TextDescTecnica.Text = lp.DESCTECNICA
                TextAbreviatura.Text = lp.ABREVIATURA
                TextOrden.Text = lp.ORDEN
                If lp.ACREDITADO = 1 Then
                    CheckAcreditado.Checked = True
                Else
                    CheckAcreditado.Checked = False
                End If
                If lp.MOSTRAR_R = 0 Then
                    ComboResultados.Text = "Ninguno"
                ElseIf lp.MOSTRAR_R = 1 Then
                    ComboResultados.Text = "Resultado 1"
                ElseIf lp.MOSTRAR_R = 2 Then
                    ComboResultados.Text = "Resultado 2"
                ElseIf lp.MOSTRAR_R = 3 Then
                    ComboResultados.Text = "Resultado 1 y 2"
                End If
                Dim tc As dTipoControl
                For Each tc In ComboTipoControl.Items
                    If tc.ID = lp.TIPOCONTROL Then
                        ComboTipoControl.SelectedItem = tc
                        Exit For
                    Else
                        ComboTipoControl.SelectedItem = Nothing
                        ComboTipoControl.Text = ""
                    End If
                Next
                If lp.OCULTAR = 1 Then
                    CheckOcultar.Checked = True
                Else
                    CheckOcultar.Checked = False
                End If
                If lp.PAQUETE = 1 Then
                    CheckPaquete.Checked = True
                Else
                    CheckPaquete.Checked = False
                End If
                listaropciones()
            End If
            TextCodigo.Focus()
        End If
        If DataGridView2.Columns(e.ColumnIndex).Name = "DescTecnica" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            id = row.Cells("Id2").Value
            lp.ID = id
            lp = lp.buscar
            If Not lp Is Nothing Then
                TextId.Text = lp.ID
                TextCodigo.Text = lp.CODIGO
                TextDescripcion.Text = lp.DESCRIPCION
                TextPrecio1.Text = lp.PRECIO1
                TextPrecio2.Text = lp.PRECIO2
                TextPrecio3.Text = lp.PRECIO3
                TextPrecio4.Text = lp.PRECIO4
                TextPrecio5.Text = lp.PRECIO5
                TextPrecio6.Text = lp.PRECIO6
                TextPrecio7.Text = lp.PRECIO5
                Dim ti As dTipoInforme
                For Each ti In ComboTI.Items
                    If ti.ID = lp.TI Then
                        ComboTI.SelectedItem = ti
                        Exit For
                    Else
                        ComboTI.SelectedItem = Nothing
                        ComboTI.Text = ""
                    End If
                Next
                TextDescTecnica.Text = lp.DESCTECNICA
                TextAbreviatura.Text = lp.ABREVIATURA
                TextOrden.Text = lp.ORDEN
                If lp.ACREDITADO = 1 Then
                    CheckAcreditado.Checked = True
                Else
                    CheckAcreditado.Checked = False
                End If
                If lp.MOSTRAR_R = 0 Then
                    ComboResultados.Text = "Ninguno"
                ElseIf lp.MOSTRAR_R = 1 Then
                    ComboResultados.Text = "Resultado 1"
                ElseIf lp.MOSTRAR_R = 2 Then
                    ComboResultados.Text = "Resultado 2"
                ElseIf lp.MOSTRAR_R = 3 Then
                    ComboResultados.Text = "Resultado 1 y 2"
                End If
                Dim tc As dTipoControl
                For Each tc In ComboTipoControl.Items
                    If tc.ID = lp.TIPOCONTROL Then
                        ComboTipoControl.SelectedItem = tc
                        Exit For
                    Else
                        ComboTipoControl.SelectedItem = Nothing
                        ComboTipoControl.Text = ""
                    End If
                Next
                If lp.OCULTAR = 1 Then
                    CheckOcultar.Checked = True
                Else
                    CheckOcultar.Checked = False
                End If
                If lp.PAQUETE = 1 Then
                    CheckPaquete.Checked = True
                Else
                    CheckPaquete.Checked = False
                End If
                listaropciones()
            End If
            TextCodigo.Focus()
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
       
    End Sub

    Private Sub ComboTipoControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTipoControl.SelectedIndexChanged
        habilitar()
    End Sub
    Private Sub habilitar()
        If ComboTipoControl.Text = "ComboBox" Then
            TextOpciones.Enabled = True
            ButtonAgregar.Enabled = True
            ButtonQuitar.Enabled = True
        ElseIf ComboTipoControl.Text = "ComboBox + TextBox" Then
            TextOpciones.Enabled = True
            ButtonAgregar.Enabled = True
            ButtonQuitar.Enabled = True
        ElseIf ComboTipoControl.Text = "TextBox" Then
            TextOpciones.Enabled = False
            ButtonAgregar.Enabled = False
            ButtonQuitar.Enabled = False
        End If
    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        guardaropcion()
    End Sub
    Private Sub guardaropcion()
        If TextId.Text <> "" Then
            Dim idanal As Long = TextId.Text
            Dim texto As String = ""
            If TextOpciones.Text <> "" Then
                texto = TextOpciones.Text
                Dim cr As New dComboResultados
                cr.ANALISIS = idanal
                cr.TEXTO = texto
                cr.guardar(Usuario)
                listaropciones()
            Else
                MsgBox("Debe ingresar una opción!")
                TextOpciones.Focus()
            End If
        Else
            MsgBox("Antes debe guardar el análisis!")
        End If
    End Sub
    Private Sub listaropciones()
        Dim cr As New dComboResultados
        Dim lista As New ArrayList
        Dim idanal As Long = TextId.Text.Trim
        lista = cr.listarxanalisis(idanal)
        ListOpciones.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each cr In lista
                    ListOpciones().Items.Add(cr)
                Next
            End If
        End If
        TextOpciones.Text = ""
    End Sub

    Private Sub ListOpciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOpciones.SelectedIndexChanged
        TextOpciones.Text = ""
        If ListOpciones.SelectedItems.Count = 1 Then
            Dim cr As dComboResultados = CType(ListOpciones.SelectedItem, dComboResultados)
            TextIdCR.Text = cr.ID
            TextOpciones.Text = cr.TEXTO
            TextOpciones.Focus()
        End If
    End Sub

    Private Sub ButtonQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuitar.Click
        If Not ListOpciones.SelectedItem Is Nothing Then
            Dim cr As New dComboResultados
            Dim id As Long = CType(TextIdCR.Text, Long)
            cr.ID = id
            If (cr.eliminar(Usuario)) Then
                MsgBox("Opción eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        TextOpciones.Text = ""
        listaropciones()
    End Sub

    Private Sub TextOpciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextOpciones.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            guardaropcion()
        End If
    End Sub

    Private Sub ButtonMetodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMetodos.Click
        If TextId.Text <> "" Then
            Dim idanal As Long = TextId.Text
            Dim v As New FormMetodos(idanal, Usuario)
            v.ShowDialog()
        Else
            MsgBox("Antes debe guardar el análisis!")
        End If

    End Sub

    Private Sub ButtonTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodos.Click
        ComboFiltro.Text = ""
        ComboFiltro2.Text = ""
        ComboFiltro.SelectedItem = Nothing
        ComboFiltro2.SelectedItem = Nothing
        cargarLista()
        cargarLista2()

    End Sub

    Private Sub ButtonTodos2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodos2.Click
        ComboFiltro.Text = ""
        ComboFiltro2.Text = ""
        ComboFiltro.SelectedItem = Nothing
        ComboFiltro2.SelectedItem = Nothing
        cargarLista()
        cargarLista2()
    End Sub
    Private Sub cargarxtipo()
        Dim l As New dListaPrecios
        Dim id As Long
        Dim codigo As String
        Dim descripcion As String
        Dim precio1 As Double
        Dim precio2 As Double
        Dim precio3 As Double
        Dim precio4 As Double
        Dim precio5 As Double
        Dim precio6 As Double
        Dim precio7 As Double
        Dim tinf As Integer
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = l.listarxti(tipo)
        If lista Is Nothing Then
            DataGridView1.Rows.Clear()
            DataGridView1.Rows.Add(1)
        Else
            DataGridView1.Rows.Clear()
            DataGridView1.Rows.Add(lista.Count)
        End If
        'DataGridView1.Rows.Clear()
        'DataGridView1.Rows.Add(lista.Count)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each l In lista
                    If l.PAQUETE = 1 Then
                        id = l.ID
                        codigo = l.CODIGO
                        descripcion = l.DESCRIPCION
                        precio1 = l.PRECIO1
                        precio2 = l.PRECIO2
                        precio3 = l.PRECIO3
                        precio4 = l.PRECIO4
                        precio5 = l.PRECIO5
                        precio6 = l.PRECIO6
                        precio7 = l.PRECIO7
                        tinf = l.TI
                        DataGridView1(columna, fila).Value = id
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = codigo
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = descripcion
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        Dim ti As New dTipoInforme
                        ti.ID = tinf
                        ti = ti.buscar
                        If Not ti Is Nothing Then
                            DataGridView1(columna, fila).Value = ti.NOMBRE
                            DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio1
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio2
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio3
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio4
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio5
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio6
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio7
                        DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = 0
                        fila = fila + 1
                    Else
                        id = l.ID
                        codigo = l.CODIGO
                        descripcion = l.DESCRIPCION
                        precio1 = l.PRECIO1
                        precio2 = l.PRECIO2
                        precio3 = l.PRECIO3
                        precio4 = l.PRECIO4
                        precio5 = l.PRECIO5
                        precio6 = l.PRECIO6
                        precio7 = l.PRECIO7
                        tinf = l.TI
                        DataGridView1(columna, fila).Value = id
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = codigo
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = descripcion
                        columna = columna + 1
                        Dim ti As New dTipoInforme
                        ti.ID = tinf
                        ti = ti.buscar
                        If Not ti Is Nothing Then
                            DataGridView1(columna, fila).Value = ti.NOMBRE
                        End If
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio1
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio2
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio3
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio4
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio5
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio6
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = precio7
                        columna = 0
                        fila = fila + 1
                    End If
                   
                Next
            End If
        End If
    End Sub
    Private Sub cargarxtipo2()
        Dim l As New dListaPrecios
        Dim id As Long
        Dim codigo As String
        Dim descripciontecnica As String
        Dim tinf As Integer
        Dim abreviatura As String
        Dim orden As Integer
        Dim tcontrol As Integer
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = l.listarxti(tipo)
        If lista Is Nothing Then
            DataGridView2.Rows.Clear()
            DataGridView2.Rows.Add(1)
        Else
            DataGridView2.Rows.Clear()
            DataGridView2.Rows.Add(lista.Count)
        End If
        'DataGridView2.Rows.Clear()
        'DataGridView2.Rows.Add(lista.Count)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each l In lista
                    If l.PAQUETE = 1 Then
                        id = l.ID
                        codigo = l.CODIGO
                        descripciontecnica = l.DESCTECNICA
                        tinf = l.TI
                        abreviatura = l.ABREVIATURA
                        orden = l.ORDEN
                        tcontrol = l.TIPOCONTROL
                        DataGridView2(columna, fila).Value = id
                        DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = codigo
                        DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = descripciontecnica
                        DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = abreviatura
                        DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = orden
                        DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        columna = columna + 1
                        Dim ti As New dTipoInforme
                        ti.ID = tinf
                        ti = ti.buscar
                        If Not ti Is Nothing Then
                            DataGridView2(columna, fila).Value = ti.NOMBRE
                            DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        columna = columna + 1
                        Dim tc As New dTipoControl
                        tc.ID = tcontrol
                        tc = tc.buscar
                        If Not tc Is Nothing Then
                            DataGridView2(columna, fila).Value = tc.NOMBRE
                            DataGridView2(columna, fila).Style.BackColor = Color.SkyBlue
                        End If
                        columna = 0
                        fila = fila + 1
                    Else
                        id = l.ID
                        codigo = l.CODIGO
                        descripciontecnica = l.DESCTECNICA
                        tinf = l.TI
                        abreviatura = l.ABREVIATURA
                        orden = l.ORDEN
                        tcontrol = l.TIPOCONTROL
                        DataGridView2(columna, fila).Value = id
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = codigo
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = descripciontecnica
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = abreviatura
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = orden
                        columna = columna + 1
                        Dim ti As New dTipoInforme
                        ti.ID = tinf
                        ti = ti.buscar
                        If Not ti Is Nothing Then
                            DataGridView2(columna, fila).Value = ti.NOMBRE
                        End If
                        columna = columna + 1

                        Dim tc As New dTipoControl
                        tc.ID = tcontrol
                        tc = tc.buscar
                        If Not tc Is Nothing Then
                            DataGridView2(columna, fila).Value = tc.NOMBRE
                        End If
                        columna = 0
                        fila = fila + 1
                    End If
                    
                Next
            End If
        End If
    End Sub

    Private Sub ComboFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboFiltro.SelectedIndexChanged
        Dim idfiltro As dTipoInforme = CType(ComboFiltro.SelectedItem, dTipoInforme)
        If Not idfiltro Is Nothing Then
            tipo = idfiltro.ID
        End If
        cargarxtipo()
        cargarxtipo2()
        If idfiltro.ID = 13 Then
            LabelResultado.Text = "En análisis de nutrición, Resultado 1 = Base húmeda / Resultado 2 = Base seca"
        Else
            LabelResultado.Text = ""
        End If
    End Sub

    Private Sub ComboFiltro2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboFiltro2.SelectedIndexChanged
        Dim idfiltro As dTipoInforme = CType(ComboFiltro2.SelectedItem, dTipoInforme)
        If Not idfiltro Is Nothing Then
            tipo = idfiltro.ID
        End If
        cargarxtipo()
        cargarxtipo2()
    End Sub

    Private Sub ComboTI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTI.SelectedIndexChanged

    End Sub

    Private Sub ButtonUnidades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUnidades.Click
        If TextId.Text <> "" Then
            Dim idanal As Long = TextId.Text
            Dim v As New FormAnalisisUnidad(idanal, Usuario)
            v.ShowDialog()
        Else
            MsgBox("Antes debe guardar el análisis!")
        End If
    End Sub

    Private Sub CheckAcreditado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAcreditado.CheckedChanged
        If TextId.Text <> "" Then
            Dim idanal As Long = TextId.Text
            If CheckAcreditado.Checked = True Then
                Dim lp As New dListaPrecios
                lp.ID = idanal
                lp.marcar_acreditado(Usuario)
            Else
                Dim lp As New dListaPrecios
                lp.ID = idanal
                lp.desmarcar_acreditado(Usuario)
            End If
        Else
            MsgBox("Antes debe guardar el análisis!")
        End If
    End Sub

    Private Sub ButtonEnsayo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnsayo.Click
        If TextId.Text <> "" Then
            Dim idanal As Long = TextId.Text
            If CheckAcreditado.Checked = True Then
                Dim v As New FormRangoAcreditacion(idanal, Usuario)
                v.ShowDialog()
            End If
        Else
            MsgBox("Antes debe guardar el análisis!")
        End If
    End Sub

    Private Sub TextFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextFiltro.TextChanged
        Dim nombre As String = TextFiltro.Text.Trim
        Dim l As New dListaPrecios
        Dim id As Long
        Dim codigo As String
        Dim descripcion As String
        Dim precio1 As Double
        Dim precio2 As Double
        Dim precio3 As Double
        Dim precio4 As Double
        Dim precio5 As Double
        Dim precio6 As Double
        Dim precio7 As Double
        Dim tinf As Integer
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = l.listarxdescripcion(nombre)
        If lista Is Nothing Then
            DataGridView1.Rows.Clear()
            DataGridView1.Rows.Add(1)
        Else
            DataGridView1.Rows.Clear()
            DataGridView1.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each l In lista
                    id = l.ID
                    codigo = l.CODIGO
                    descripcion = l.DESCRIPCION
                    precio1 = l.PRECIO1
                    precio2 = l.PRECIO2
                    precio3 = l.PRECIO3
                    precio4 = l.PRECIO4
                    precio5 = l.PRECIO5
                    precio6 = l.PRECIO6
                    precio7 = l.PRECIO7
                    tinf = l.TI
                    DataGridView1(columna, fila).Value = id
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = codigo
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = descripcion
                    columna = columna + 1
                    Dim ti As New dTipoInforme
                    ti.ID = tinf
                    ti = ti.buscar
                    If Not ti Is Nothing Then
                        DataGridView1(columna, fila).Value = ti.NOMBRE
                    End If
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = precio1
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = precio2
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = precio3
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = precio4
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = precio5
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = precio6
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = precio7
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub ButtonDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDuplicar.Click
        If TextId.Text <> "" Then
            Dim analisis As Integer = 0
            Dim v As New FormSeleccionarTipoInforme
            v.ShowDialog()

            Dim ida As Integer = 0
            ida = TextId.Text.Trim
            Dim lp As New dListaPrecios
            lp.ID = ida
            lp = lp.buscar
            If Not lp Is Nothing Then
                Dim lp2 As New dListaPrecios
                lp2.CODIGO = lp.CODIGO
                lp2.DESCRIPCION = lp.DESCRIPCION
                lp2.PRECIO1 = lp.PRECIO1
                lp2.PRECIO2 = lp.PRECIO2
                lp2.PRECIO3 = lp.PRECIO3
                lp2.PRECIO4 = lp.PRECIO4
                lp2.PRECIO5 = lp.PRECIO5
                lp2.PRECIO6 = lp.PRECIO6
                lp2.PRECIO7 = lp.PRECIO7
                lp2.TI = idti
                lp2.DESCTECNICA = lp.DESCTECNICA
                lp2.TIPOCONTROL = lp.TIPOCONTROL
                lp2.ABREVIATURA = lp.ABREVIATURA
                lp2.ACREDITADO = lp.ACREDITADO
                lp2.ORDEN = lp.ORDEN
                lp2.OCULTAR = lp.OCULTAR
                lp2.PAQUETE = lp.PAQUETE
                lp2.MOSTRAR_R = lp.MOSTRAR_R
                If (lp2.guardar(Usuario)) Then
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If

                Dim lpx As New dListaPrecios
                lpx = lpx.buscarultimo
                If Not lpx Is Nothing Then
                    analisis = lpx.ID
                End If
                lpx = Nothing

                Dim a As New dAnalisisUnidad
                Dim lista_a As New ArrayList
                lista_a = a.listarxanalisis(ida)
                If Not lista_a Is Nothing Then
                    For Each a In lista_a
                        Dim aa As New dAnalisisUnidad
                        aa.ANALISIS = analisis
                        aa.UNIDAD = a.UNIDAD
                        aa.PORDEFECTO = a.PORDEFECTO
                        aa.guardar(Usuario)
                        aa = Nothing
                    Next
                End If

                Dim m As New dListaMetodos
                Dim lista_m As New ArrayList
                lista_m = m.listarxanalisis(ida)
                If Not lista_m Is Nothing Then
                    For Each m In lista_m
                        Dim mm As New dListaMetodos
                        mm.ANALISIS = analisis
                        mm.METODO = m.METODO
                        mm.PORDEFECTO = m.PORDEFECTO
                        mm.guardar(Usuario)
                        mm = Nothing
                    Next
                End If

                Dim cr As New dComboResultados
                Dim lista_cr As New ArrayList
                lista_cr = cr.listarxanalisis(ida)
                If Not lista_cr Is Nothing Then
                    For Each cr In lista_cr
                        Dim cr2 As New dComboResultados
                        cr2.ANALISIS = analisis
                        cr2.TEXTO = cr.TEXTO
                        cr2.guardar(Usuario)
                        cr2 = Nothing
                    Next
                End If


            End If
            limpiar()
            If ComboFiltro.Text <> "" Or ComboFiltro2.Text <> "" Then
                cargarxtipo()
                cargarxtipo2()
            Else
                cargarLista()
                cargarLista2()
            End If
        End If
    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub ButtonMeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMeta.Click
        If TextId.Text <> "" Then
            Dim idanal As Long = TextId.Text
            Dim v As New FormMeta(idanal, Usuario)
            v.ShowDialog()
        Else
            MsgBox("Antes debe guardar el análisis!")
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TextId.Text <> "" Then
            Dim idanal As Long = TextId.Text
            Dim v As New FormReferencias(idanal, Usuario)
            v.ShowDialog()
        Else
            MsgBox("Antes debe guardar el análisis!")
        End If
    End Sub
End Class