Public Class FormCompletoATB
    Private _usuario As dUsuario
    Private _idnuevoanalisis As Long
    Private _idanal As Integer
    Private id_ As Long
    Private _ficha As Long
    Private _muestra As String
    Private solo_aislamiento As Integer = 0
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal muestra As String, ByVal u As dUsuario, ByVal idanal As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        _idnuevoanalisis = id
        _idanal = idanal
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        _muestra = muestra
        _ficha = ficha
        listar_aislamientos()
        chequear_tipo_analisis()
        mostrar_resultado()

    End Sub
#End Region
    Private Sub chequear_tipo_analisis()
        If _idanal = 11 Or _idanal = 316 Then
            DataGridView1.Enabled = False
            DataGridView2.Enabled = False
            solo_aislamiento = 1
        End If
    End Sub
    Private Sub mostrar_resultado()
        Dim atb As New dATB
        Dim lista As New ArrayList
        Dim primero As Integer = 0
        Dim segundo As Integer = 0
        lista = atb.listardiferentes(_ficha, _muestra)
        If Not lista Is Nothing Then
            If lista.Count = 1 Then
                For Each atb In lista
                    primero = atb.AISLAMIENTO
                Next
            ElseIf lista.Count = 2 Then
                Dim contador As Integer = 1
                For Each atb In lista
                    If contador = 1 Then
                        primero = atb.AISLAMIENTO
                    ElseIf contador = 2 Then
                        segundo = atb.AISLAMIENTO
                    End If
                    contador = contador + 1
                Next
            End If
            If primero <> 0 Then
                Dim moa As dMOA24
                For Each moa In ComboAislamiento1.Items
                    If moa.ID = primero Then
                        ComboAislamiento1.SelectedItem = moa
                        If _idanal = 11 And _idanal = 316 Then
                            listar_atb()
                        End If
                        Exit For
                    End If
                Next
            End If
            If segundo <> 0 Then
                Dim moa As dMOA24
                For Each moa In ComboAislamiento2.Items
                    If moa.ID = segundo Then
                        ComboAislamiento2.SelectedItem = moa
                        If _idanal = 11 And _idanal = 316 Then
                            listar_atb2()
                        End If
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub ComboAislamiento1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboAislamiento1.SelectedIndexChanged
        If solo_aislamiento = 0 Then

            listar_atb()

        Else
            Dim aislamiento As dMOA24 = CType(ComboAislamiento1.SelectedItem, dMOA24)
            Dim idaislamiento As Integer = 0
            idaislamiento = aislamiento.ID

            Dim id As Integer = 0
            Dim id_ As Long = 0
            Dim ficha As Long = 0
            Dim muestra As String = ""
            Dim atb_ As Integer = 0
            Dim resist As String = ""
            Dim modifica As Integer = 0

            ficha = _ficha
            muestra = _muestra

            Dim atb As New dATB
            atb.FICHA = ficha
            atb.MUESTRA = muestra
            atb.AISLAMIENTO = idaislamiento
            atb.ATB = atb_
            atb = atb.buscarxfichaxmuestra
            If Not atb Is Nothing Then
                modifica = 1
                id_ = atb.ID
            Else
                modifica = 0
            End If
            If modifica = 1 Then
                Dim atb2 As New dATB
                atb2.ID = id_
                atb2.FICHA = ficha
                atb2.MUESTRA = muestra
                atb2.AISLAMIENTO = idaislamiento
                atb2.ATB = atb_
                atb2.RESISTENCIA = resist
                atb2.modificar(Usuario)
            Else
                Dim atb2 As New dATB
                atb2.FICHA = ficha
                atb2.MUESTRA = muestra
                atb2.AISLAMIENTO = idaislamiento
                atb2.ATB = atb_
                atb2.RESISTENCIA = resist
                atb2.guardar(Usuario)
            End If
        End If
    End Sub
    Private Sub listar_atb()
        Dim aislamiento As dMOA24 = CType(ComboAislamiento1.SelectedItem, dMOA24)
        Dim idaislamiento As Integer = 0
        idaislamiento = aislamiento.ID
        Dim lista As New ArrayList
        Dim ma As New dMicroATB
        lista = ma.listarxmicro(idaislamiento)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
            For Each ma In lista
                DataGridView1(columna, fila).Value = ma.ID
                columna = columna + 1
                Dim a As New dAntibioticos
                a.ID = ma.ATB
                a = a.buscar
                If Not a Is Nothing Then
                    DataGridView1(columna, fila).Value = a.NOMBRE
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = a.NOMBRE
                    columna = columna + 1
                End If
                Dim atb As New dATB
                atb.FICHA = _ficha
                atb.MUESTRA = _muestra
                atb.AISLAMIENTO = idaislamiento
                atb.ATB = ma.ATB
                atb = atb.buscarxfichaxmuestra
                If Not atb Is Nothing Then
                    DataGridView1(columna, fila).Value = atb.RESISTENCIA
                    columna = 0
                    fila = fila + 1
                Else
                    DataGridView1(columna, fila).Value = ""
                    columna = 0
                    fila = fila + 1
                End If

            Next
        Else
            Dim id As Integer = 0
            Dim id_ As Long = 0
            Dim ficha As Long = 0
            Dim muestra As String = ""
            Dim atb_ As Integer = 0
            Dim resist As String = ""
            Dim modifica As Integer = 0

            ficha = _ficha
            muestra = _muestra

            Dim atb As New dATB
            atb.FICHA = ficha
            atb.MUESTRA = muestra
            atb.AISLAMIENTO = idaislamiento
            atb.ATB = atb_
            atb = atb.buscarxfichaxmuestra
            If Not atb Is Nothing Then
                modifica = 1
                id_ = atb.ID
            Else
                modifica = 0
            End If
            If modifica = 1 Then
                Dim atb2 As New dATB
                atb2.ID = id_
                atb2.FICHA = ficha
                atb2.MUESTRA = muestra
                atb2.AISLAMIENTO = idaislamiento
                atb2.ATB = atb_
                atb2.RESISTENCIA = resist
                atb2.modificar(Usuario)
            Else
                Dim atb2 As New dATB
                atb2.FICHA = ficha
                atb2.MUESTRA = muestra
                atb2.AISLAMIENTO = idaislamiento
                atb2.ATB = atb_
                atb2.RESISTENCIA = resist
                atb2.guardar(Usuario)
            End If
        End If
    End Sub
    Private Sub listar_atb2()
        Dim aislamiento As dMOA24 = CType(ComboAislamiento2.SelectedItem, dMOA24)
        Dim idaislamiento As Integer = 0
        idaislamiento = aislamiento.ID
        Dim lista As New ArrayList
        Dim ma As New dMicroATB
        lista = ma.listarxmicro(idaislamiento)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView2.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView2.Rows.Add(lista.Count)
            For Each ma In lista
                DataGridView2(columna, fila).Value = ma.ID
                columna = columna + 1
                Dim a As New dAntibioticos
                a.ID = ma.ATB
                a = a.buscar
                If Not a Is Nothing Then
                    DataGridView2(columna, fila).Value = a.NOMBRE
                    columna = columna + 1
                Else
                    DataGridView2(columna, fila).Value = a.NOMBRE
                    columna = columna + 1
                End If
                Dim atb As New dATB
                atb.FICHA = _ficha
                atb.MUESTRA = _muestra
                atb.AISLAMIENTO = idaislamiento
                atb.ATB = ma.ATB
                atb = atb.buscarxfichaxmuestra
                If Not atb Is Nothing Then
                    DataGridView2(columna, fila).Value = atb.RESISTENCIA
                    columna = 0
                    fila = fila + 1
                Else
                    DataGridView2(columna, fila).Value = ""
                    columna = 0
                    fila = fila + 1
                End If
            Next
        Else
            Dim id As Integer = 0
            Dim id_ As Long = 0
            Dim ficha As Long = 0
            Dim muestra As String = ""
            Dim atb_ As Integer = 0
            Dim resist As String = ""
            Dim modifica As Integer = 0

            ficha = _ficha
            muestra = _muestra

            Dim atb As New dATB
            atb.FICHA = ficha
            atb.MUESTRA = muestra
            atb.AISLAMIENTO = idaislamiento
            atb.ATB = atb_
            atb = atb.buscarxfichaxmuestra
            If Not atb Is Nothing Then
                modifica = 1
                id_ = atb.ID
            Else
                modifica = 0
            End If
            If modifica = 1 Then
                Dim atb2 As New dATB
                atb2.ID = id_
                atb2.FICHA = ficha
                atb2.MUESTRA = muestra
                atb2.AISLAMIENTO = idaislamiento
                atb2.ATB = atb_
                atb2.RESISTENCIA = resist
                atb2.modificar(Usuario)
            Else
                Dim atb2 As New dATB
                atb2.FICHA = ficha
                atb2.MUESTRA = muestra
                atb2.AISLAMIENTO = idaislamiento
                atb2.ATB = atb_
                atb2.RESISTENCIA = resist
                atb2.guardar(Usuario)
            End If
        End If
    End Sub
    Private Sub listar_aislamientos()
        Dim a As New dMOA24
        Dim lista As New ArrayList
        lista = a.listar()
        If Not lista Is Nothing Then
            For Each a In lista
                ComboAislamiento1.Items.Add(a)
                ComboAislamiento2.Items.Add(a)
            Next
        End If
    End Sub

    Private Sub ComboAislamiento2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboAislamiento2.SelectedIndexChanged
        If solo_aislamiento = 0 Then
            listar_atb2()
        Else
            Dim aislamiento As dMOA24 = CType(ComboAislamiento2.SelectedItem, dMOA24)
            Dim idaislamiento As Integer = 0
            idaislamiento = aislamiento.ID

            Dim id As Integer = 0
            Dim id_ As Long = 0
            Dim ficha As Long = 0
            Dim muestra As String = ""
            Dim atb_ As Integer = 0
            Dim resist As String = ""
            Dim modifica As Integer = 0

            ficha = _ficha
            muestra = _muestra

            Dim atb As New dATB
            atb.FICHA = ficha
            atb.MUESTRA = muestra
            atb.AISLAMIENTO = idaislamiento
            atb.ATB = atb_
            atb = atb.buscarxfichaxmuestra
            If Not atb Is Nothing Then
                modifica = 1
                id_ = atb.ID
            Else
                modifica = 0
            End If
            If modifica = 1 Then
                Dim atb2 As New dATB
                atb2.ID = id_
                atb2.FICHA = ficha
                atb2.MUESTRA = muestra
                atb2.AISLAMIENTO = idaislamiento
                atb2.ATB = atb_
                atb2.RESISTENCIA = resist
                atb2.modificar(Usuario)
            Else
                Dim atb2 As New dATB
                atb2.FICHA = ficha
                atb2.MUESTRA = muestra
                atb2.AISLAMIENTO = idaislamiento
                atb2.ATB = atb_
                atb2.RESISTENCIA = resist
                atb2.guardar(Usuario)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Completar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id").Value
            Dim v As New FormCompletoATB2(id, _ficha, _muestra, Usuario)
            v.ShowDialog()
        End If
        listar_atb()

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If DataGridView2.Columns(e.ColumnIndex).Name = "Completar2" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id2").Value
            Dim v As New FormCompletoATB2(id, _ficha, _muestra, Usuario)
            v.ShowDialog()
            listar_atb2()
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class