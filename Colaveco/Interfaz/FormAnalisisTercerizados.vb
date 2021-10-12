Public Class FormAnalisisTercerizados
    Private idficha As String
    Private _usuario As dUsuario
    Private idtipoinf As Integer = 0
    Private ficha As Long = 0
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal f As Long, ByVal t As Integer)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        ficha = f
        idtipoinf = t
        listaranalisis()
        listaranalisis2()
    End Sub
#End Region
    Private Sub listaranalisis()
        Dim at As New dAnalisisTercerizadoTipo
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = at.listarportipoinforme(idtipoinf)
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add(lista.Count)
        If Not lista Is Nothing Then
            For Each at In lista
                DataGridView1(columna, fila).Value = at.ID
                columna = columna + 1
                DataGridView1(columna, fila).Value = at.NOMBRE
                columna = 0
                fila = fila + 1
            Next
        End If
    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        agregar()
    End Sub
    Private Sub agregar()
        If TextMuestras.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado muestra", MsgBoxStyle.Exclamation, "Atención") : TextMuestras.Focus() : Exit Sub
        Dim muestra As String = TextMuestras.Text
        Dim a As New dAnalisisTercerizado
        a.FICHA = ficha
        a.MUESTRA = muestra
        a = a.buscarrepetidas()
        If Not a Is Nothing Then
            My.Computer.Audio.Play("c:\debug\aviso.wav")
            Dim result = MessageBox.Show("La muestra ya existe, desea agregarla?", "Atención", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                Exit Sub
                a = Nothing
            End If
        End If
        Dim listaanalisis As New ArrayList
        Dim listaanalisis2 As New ArrayList
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(2).Value = True Then
                listaanalisis.Add(row.Cells(0).Value)
            End If
        Next
        '*******************************************************************************
        Dim lista As New ArrayList
        For indice As Integer = 0 To listaanalisis.Count - 1 Step 1
            Dim id As Integer = 0
            id = listaanalisis.Item(indice)
            listaanalisis2.Add(id)
        Next


        Dim resultado As String = ""
        Dim metodo As String = ""
        Dim unidad As String = ""
        Dim orden As Integer = 0
        Dim a2 As New dAnalisisTercerizado
        Dim fechaingreso As Date = DateFechaIngreso.Value.ToString("yyyy-MM-dd")
        Dim fecing As String
        fecing = Format(fechaingreso, "yyyy-MM-dd")

        Dim listadependientes As New ArrayList
        Dim at2 As New dAnalisisTercerizadoTipo
        Dim ax As Integer = 0
        For indice As Integer = 0 To listaanalisis2.Count - 1 Step 1
            ax = listaanalisis2.Item(indice)
            listadependientes = at2.listardependientes(ax)
            If Not listadependientes Is Nothing Then
                For Each at2 In listadependientes
                    a2.FICHA = ficha
                    a2.MUESTRA = muestra
                    a2.TIPOINFORME = idtipoinf
                    a2.ANALISIS = at2.ID
                    a2.RESULTADO = resultado
                    Dim att As New dAnalisisTercerizadoTipo
                    att.ID = a2.ANALISIS
                    att = att.buscar
                    If Not att Is Nothing Then
                        metodo = att.METODO
                        unidad = att.UNIDAD
                        orden = att.ORDEN
                    End If
                    att = Nothing
                    a2.METODO = metodo
                    a2.UNIDAD = unidad
                    a2.ORDEN = orden
                    a2.FECHAPROCESO = fecing
                    a2.guardar(Usuario)
                Next
            Else
                a2.FICHA = ficha
                a2.MUESTRA = muestra
                a2.TIPOINFORME = idtipoinf
                a2.ANALISIS = listaanalisis2.Item(indice)
                a2.RESULTADO = resultado
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = a2.ANALISIS
                att = att.buscar
                If Not att Is Nothing Then
                    metodo = att.METODO
                    unidad = att.UNIDAD
                    orden = att.ORDEN
                End If
                att = Nothing
                a2.METODO = metodo
                a2.UNIDAD = unidad
                a2.ORDEN = orden
                a2.FECHAPROCESO = fecing
                a2.guardar(Usuario)
            End If
            listaranalisis2()
            TextMuestras.Text = ""
            TextMuestras.Focus()

            'a2.FICHA = ficha
            'a2.MUESTRA = muestra
            'a2.TIPOINFORME = idtipoinf
            'a2.ANALISIS = listaanalisis2.Item(indice)
            'a2.RESULTADO = resultado
            'Dim att As New dAnalisisTercerizadoTipo
            'att.ID = a2.ANALISIS
            'att = att.buscar
            'If Not att Is Nothing Then
            '    metodo = att.METODO
            '    unidad = att.UNIDAD
            'End If
            'att = Nothing
            'a2.METODO = metodo
            'a2.UNIDAD = unidad
            'a2.FECHAPROCESO = fecing
            'a2.guardar(Usuario)

            'listaranalisis2()
            'TextMuestras.Text = ""
            'TextMuestras.Focus()
        Next
        '*******************************************************************************
        a2 = Nothing
        at2 = Nothing
    End Sub
    Private Sub listaranalisis2()
        Dim a As New dAnalisisTercerizado
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = a.listarporficha2(ficha)
        DataGridView2.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView2.Rows.Add(lista.Count)
            For Each a In lista
                DataGridView2(columna, fila).Value = a.ID
                columna = columna + 1
                DataGridView2(columna, fila).Value = a.MUESTRA
                columna = columna + 1
                Dim at As New dAnalisisTercerizadoTipo
                at.ID = a.ANALISIS
                at = at.buscar
                DataGridView2(columna, fila).Value = at.NOMBRE
                columna = 0
                fila = fila + 1
            Next
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If DataGridView2.Columns(e.ColumnIndex).Name = "Quitar2" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id2").Value
            Dim n As New dAnalisisTercerizado
            n.ID = id
            n.eliminar(Usuario)
            listaranalisis2()
            '*******************************************************************************
        End If
    End Sub

    Private Sub TextMuestras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMuestras.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            agregar()
        End If
    End Sub

End Class