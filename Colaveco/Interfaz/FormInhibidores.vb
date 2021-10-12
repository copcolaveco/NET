Public Class FormInhibidores
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
        cargarcombocolumna()
        cargarcombofila()
        cargarcomboresultado()
        cargarxdefecto()
        buscarultimonumero()
        listar()

    End Sub

#End Region
    Public Sub cargarcombocolumna()
        ComboColumna.Items.Add("1")
        ComboColumna.Items.Add("2")
        ComboColumna.Items.Add("3")
        ComboColumna.Items.Add("4")
        ComboColumna.Items.Add("5")
        ComboColumna.Items.Add("6")
        ComboColumna.Items.Add("7")
        ComboColumna.Items.Add("8")
        ComboColumna.Items.Add("9")
        ComboColumna.Items.Add("10")
        ComboColumna.Items.Add("11")
        ComboColumna.Items.Add("12")
    End Sub
    Public Sub cargarcombofila()
        ComboFila.Items.Add("A")
        ComboFila.Items.Add("B")
        ComboFila.Items.Add("C")
        ComboFila.Items.Add("D")
        ComboFila.Items.Add("E")
        ComboFila.Items.Add("F")
        ComboFila.Items.Add("G")
        ComboFila.Items.Add("H")
    End Sub
    Public Sub cargarcomboresultado()
        ComboResultado.Items.Add("Negativo")
        ComboResultado.Items.Add("Positivo")
    End Sub
    Private Sub cargarxdefecto()
        ComboColumna.Text = "1"
        ComboFila.Text = "A"
        ComboResultado.Text = "Negativo"
    End Sub
    'Private Sub columnafila()
    '    If ComboColumna.Text = "1" And ComboFila.Text = "A" Then
    '        ComboColumna.Text = "2"
    '        ComboFila.Text = "A"
    '    ElseIf ComboColumna.Text = "2" And ComboFila.Text = "A" Then
    '        ComboColumna.Text = "1"
    '        ComboFila.Text = "B"
    '    ElseIf ComboColumna.Text = "1" And ComboFila.Text = "B" Then
    '        ComboColumna.Text = "2"
    '        ComboFila.Text = "B"
    '    ElseIf ComboColumna.Text = "2" And ComboFila.Text = "B" Then
    '        ComboColumna.Text = "1"
    '        ComboFila.Text = "C"
    '    ElseIf ComboColumna.Text = "1" And ComboFila.Text = "C" Then
    '        ComboColumna.Text = "2"
    '        ComboFila.Text = "C"
    '    ElseIf ComboColumna.Text = "2" And ComboFila.Text = "C" Then
    '        ComboColumna.Text = "1"
    '        ComboFila.Text = "D"
    '    ElseIf ComboColumna.Text = "1" And ComboFila.Text = "D" Then
    '        ComboColumna.Text = "2"
    '        ComboFila.Text = "D"
    '    ElseIf ComboColumna.Text = "2" And ComboFila.Text = "D" Then
    '        ComboColumna.Text = "1"
    '        ComboFila.Text = "E"
    '    ElseIf ComboColumna.Text = "1" And ComboFila.Text = "E" Then
    '        ComboColumna.Text = "2"
    '        ComboFila.Text = "E"
    '    ElseIf ComboColumna.Text = "2" And ComboFila.Text = "E" Then
    '        ComboColumna.Text = "1"
    '        ComboFila.Text = "F"
    '    ElseIf ComboColumna.Text = "1" And ComboFila.Text = "F" Then
    '        ComboColumna.Text = "2"
    '        ComboFila.Text = "F"
    '    ElseIf ComboColumna.Text = "2" And ComboFila.Text = "F" Then
    '        ComboColumna.Text = "1"
    '        ComboFila.Text = "G"
    '    ElseIf ComboColumna.Text = "1" And ComboFila.Text = "G" Then
    '        ComboColumna.Text = "2"
    '        ComboFila.Text = "G"
    '    ElseIf ComboColumna.Text = "2" And ComboFila.Text = "G" Then
    '        ComboColumna.Text = "1"
    '        ComboFila.Text = "H"
    '    ElseIf ComboColumna.Text = "1" And ComboFila.Text = "H" Then
    '        ComboColumna.Text = "2"
    '        ComboFila.Text = "H"
    '    ElseIf ComboColumna.Text = "2" And ComboFila.Text = "H" Then
    '        ComboColumna.Text = "3"
    '        ComboFila.Text = "A"
    '        '************************************************************
    '    ElseIf ComboColumna.Text = "3" And ComboFila.Text = "A" Then
    '        ComboColumna.Text = "4"
    '        ComboFila.Text = "A"
    '    ElseIf ComboColumna.Text = "4" And ComboFila.Text = "A" Then
    '        ComboColumna.Text = "3"
    '        ComboFila.Text = "B"
    '    ElseIf ComboColumna.Text = "3" And ComboFila.Text = "B" Then
    '        ComboColumna.Text = "4"
    '        ComboFila.Text = "B"
    '    ElseIf ComboColumna.Text = "4" And ComboFila.Text = "B" Then
    '        ComboColumna.Text = "3"
    '        ComboFila.Text = "C"
    '    ElseIf ComboColumna.Text = "3" And ComboFila.Text = "C" Then
    '        ComboColumna.Text = "4"
    '        ComboFila.Text = "C"
    '    ElseIf ComboColumna.Text = "4" And ComboFila.Text = "C" Then
    '        ComboColumna.Text = "3"
    '        ComboFila.Text = "D"
    '    ElseIf ComboColumna.Text = "3" And ComboFila.Text = "D" Then
    '        ComboColumna.Text = "4"
    '        ComboFila.Text = "D"
    '    ElseIf ComboColumna.Text = "4" And ComboFila.Text = "D" Then
    '        ComboColumna.Text = "3"
    '        ComboFila.Text = "E"
    '    ElseIf ComboColumna.Text = "3" And ComboFila.Text = "E" Then
    '        ComboColumna.Text = "4"
    '        ComboFila.Text = "E"
    '    ElseIf ComboColumna.Text = "4" And ComboFila.Text = "E" Then
    '        ComboColumna.Text = "3"
    '        ComboFila.Text = "F"
    '    ElseIf ComboColumna.Text = "3" And ComboFila.Text = "F" Then
    '        ComboColumna.Text = "4"
    '        ComboFila.Text = "F"
    '    ElseIf ComboColumna.Text = "4" And ComboFila.Text = "F" Then
    '        ComboColumna.Text = "3"
    '        ComboFila.Text = "G"
    '    ElseIf ComboColumna.Text = "3" And ComboFila.Text = "G" Then
    '        ComboColumna.Text = "4"
    '        ComboFila.Text = "G"
    '    ElseIf ComboColumna.Text = "4" And ComboFila.Text = "G" Then
    '        ComboColumna.Text = "3"
    '        ComboFila.Text = "H"
    '    ElseIf ComboColumna.Text = "3" And ComboFila.Text = "H" Then
    '        ComboColumna.Text = "4"
    '        ComboFila.Text = "H"
    '    ElseIf ComboColumna.Text = "4" And ComboFila.Text = "H" Then
    '        ComboColumna.Text = "5"
    '        ComboFila.Text = "A"
    '        '************************************************************
    '    ElseIf ComboColumna.Text = "5" And ComboFila.Text = "A" Then
    '        ComboColumna.Text = "6"
    '        ComboFila.Text = "A"
    '    ElseIf ComboColumna.Text = "6" And ComboFila.Text = "A" Then
    '        ComboColumna.Text = "5"
    '        ComboFila.Text = "B"
    '    ElseIf ComboColumna.Text = "5" And ComboFila.Text = "B" Then
    '        ComboColumna.Text = "6"
    '        ComboFila.Text = "B"
    '    ElseIf ComboColumna.Text = "6" And ComboFila.Text = "B" Then
    '        ComboColumna.Text = "5"
    '        ComboFila.Text = "C"
    '    ElseIf ComboColumna.Text = "5" And ComboFila.Text = "C" Then
    '        ComboColumna.Text = "6"
    '        ComboFila.Text = "C"
    '    ElseIf ComboColumna.Text = "6" And ComboFila.Text = "C" Then
    '        ComboColumna.Text = "5"
    '        ComboFila.Text = "D"
    '    ElseIf ComboColumna.Text = "5" And ComboFila.Text = "D" Then
    '        ComboColumna.Text = "6"
    '        ComboFila.Text = "D"
    '    ElseIf ComboColumna.Text = "6" And ComboFila.Text = "D" Then
    '        ComboColumna.Text = "5"
    '        ComboFila.Text = "E"
    '    ElseIf ComboColumna.Text = "5" And ComboFila.Text = "E" Then
    '        ComboColumna.Text = "6"
    '        ComboFila.Text = "E"
    '    ElseIf ComboColumna.Text = "6" And ComboFila.Text = "E" Then
    '        ComboColumna.Text = "5"
    '        ComboFila.Text = "F"
    '    ElseIf ComboColumna.Text = "5" And ComboFila.Text = "F" Then
    '        ComboColumna.Text = "6"
    '        ComboFila.Text = "F"
    '    ElseIf ComboColumna.Text = "6" And ComboFila.Text = "F" Then
    '        ComboColumna.Text = "5"
    '        ComboFila.Text = "G"
    '    ElseIf ComboColumna.Text = "5" And ComboFila.Text = "G" Then
    '        ComboColumna.Text = "6"
    '        ComboFila.Text = "G"
    '    ElseIf ComboColumna.Text = "6" And ComboFila.Text = "G" Then
    '        ComboColumna.Text = "5"
    '        ComboFila.Text = "H"
    '    ElseIf ComboColumna.Text = "5" And ComboFila.Text = "H" Then
    '        ComboColumna.Text = "6"
    '        ComboFila.Text = "H"
    '    ElseIf ComboColumna.Text = "6" And ComboFila.Text = "H" Then
    '        ComboColumna.Text = "7"
    '        ComboFila.Text = "A"
    '        '************************************************************
    '    ElseIf ComboColumna.Text = "7" And ComboFila.Text = "A" Then
    '        ComboColumna.Text = "8"
    '        ComboFila.Text = "A"
    '    ElseIf ComboColumna.Text = "8" And ComboFila.Text = "A" Then
    '        ComboColumna.Text = "7"
    '        ComboFila.Text = "B"
    '    ElseIf ComboColumna.Text = "7" And ComboFila.Text = "B" Then
    '        ComboColumna.Text = "8"
    '        ComboFila.Text = "B"
    '    ElseIf ComboColumna.Text = "8" And ComboFila.Text = "B" Then
    '        ComboColumna.Text = "7"
    '        ComboFila.Text = "C"
    '    ElseIf ComboColumna.Text = "7" And ComboFila.Text = "C" Then
    '        ComboColumna.Text = "8"
    '        ComboFila.Text = "C"
    '    ElseIf ComboColumna.Text = "8" And ComboFila.Text = "C" Then
    '        ComboColumna.Text = "7"
    '        ComboFila.Text = "D"
    '    ElseIf ComboColumna.Text = "7" And ComboFila.Text = "D" Then
    '        ComboColumna.Text = "8"
    '        ComboFila.Text = "D"
    '    ElseIf ComboColumna.Text = "8" And ComboFila.Text = "D" Then
    '        ComboColumna.Text = "7"
    '        ComboFila.Text = "E"
    '    ElseIf ComboColumna.Text = "7" And ComboFila.Text = "E" Then
    '        ComboColumna.Text = "8"
    '        ComboFila.Text = "E"
    '    ElseIf ComboColumna.Text = "8" And ComboFila.Text = "E" Then
    '        ComboColumna.Text = "7"
    '        ComboFila.Text = "F"
    '    ElseIf ComboColumna.Text = "7" And ComboFila.Text = "F" Then
    '        ComboColumna.Text = "8"
    '        ComboFila.Text = "F"
    '    ElseIf ComboColumna.Text = "8" And ComboFila.Text = "F" Then
    '        ComboColumna.Text = "7"
    '        ComboFila.Text = "G"
    '    ElseIf ComboColumna.Text = "7" And ComboFila.Text = "G" Then
    '        ComboColumna.Text = "8"
    '        ComboFila.Text = "G"
    '    ElseIf ComboColumna.Text = "8" And ComboFila.Text = "G" Then
    '        ComboColumna.Text = "7"
    '        ComboFila.Text = "H"
    '    ElseIf ComboColumna.Text = "7" And ComboFila.Text = "H" Then
    '        ComboColumna.Text = "8"
    '        ComboFila.Text = "H"
    '    ElseIf ComboColumna.Text = "8" And ComboFila.Text = "H" Then
    '        ComboColumna.Text = "9"
    '        ComboFila.Text = "A"
    '        '************************************************************
    '    ElseIf ComboColumna.Text = "9" And ComboFila.Text = "A" Then
    '        ComboColumna.Text = "10"
    '        ComboFila.Text = "A"
    '    ElseIf ComboColumna.Text = "10" And ComboFila.Text = "A" Then
    '        ComboColumna.Text = "9"
    '        ComboFila.Text = "B"
    '    ElseIf ComboColumna.Text = "9" And ComboFila.Text = "B" Then
    '        ComboColumna.Text = "10"
    '        ComboFila.Text = "B"
    '    ElseIf ComboColumna.Text = "10" And ComboFila.Text = "B" Then
    '        ComboColumna.Text = "9"
    '        ComboFila.Text = "C"
    '    ElseIf ComboColumna.Text = "9" And ComboFila.Text = "C" Then
    '        ComboColumna.Text = "10"
    '        ComboFila.Text = "C"
    '    ElseIf ComboColumna.Text = "10" And ComboFila.Text = "C" Then
    '        ComboColumna.Text = "9"
    '        ComboFila.Text = "D"
    '    ElseIf ComboColumna.Text = "9" And ComboFila.Text = "D" Then
    '        ComboColumna.Text = "10"
    '        ComboFila.Text = "D"
    '    ElseIf ComboColumna.Text = "10" And ComboFila.Text = "D" Then
    '        ComboColumna.Text = "9"
    '        ComboFila.Text = "E"
    '    ElseIf ComboColumna.Text = "9" And ComboFila.Text = "E" Then
    '        ComboColumna.Text = "10"
    '        ComboFila.Text = "E"
    '    ElseIf ComboColumna.Text = "10" And ComboFila.Text = "E" Then
    '        ComboColumna.Text = "9"
    '        ComboFila.Text = "F"
    '    ElseIf ComboColumna.Text = "9" And ComboFila.Text = "F" Then
    '        ComboColumna.Text = "10"
    '        ComboFila.Text = "F"
    '    ElseIf ComboColumna.Text = "10" And ComboFila.Text = "F" Then
    '        ComboColumna.Text = "9"
    '        ComboFila.Text = "G"
    '    ElseIf ComboColumna.Text = "9" And ComboFila.Text = "G" Then
    '        ComboColumna.Text = "10"
    '        ComboFila.Text = "G"
    '    ElseIf ComboColumna.Text = "10" And ComboFila.Text = "G" Then
    '        ComboColumna.Text = "9"
    '        ComboFila.Text = "H"
    '    ElseIf ComboColumna.Text = "9" And ComboFila.Text = "H" Then
    '        ComboColumna.Text = "10"
    '        ComboFila.Text = "H"
    '    ElseIf ComboColumna.Text = "10" And ComboFila.Text = "H" Then
    '        ComboColumna.Text = "11"
    '        ComboFila.Text = "A"
    '        '************************************************************
    '    ElseIf ComboColumna.Text = "11" And ComboFila.Text = "A" Then
    '        ComboColumna.Text = "12"
    '        ComboFila.Text = "A"
    '    ElseIf ComboColumna.Text = "12" And ComboFila.Text = "A" Then
    '        ComboColumna.Text = "11"
    '        ComboFila.Text = "B"
    '    ElseIf ComboColumna.Text = "11" And ComboFila.Text = "B" Then
    '        ComboColumna.Text = "12"
    '        ComboFila.Text = "B"
    '    ElseIf ComboColumna.Text = "12" And ComboFila.Text = "B" Then
    '        ComboColumna.Text = "11"
    '        ComboFila.Text = "C"
    '    ElseIf ComboColumna.Text = "11" And ComboFila.Text = "C" Then
    '        ComboColumna.Text = "12"
    '        ComboFila.Text = "C"
    '    ElseIf ComboColumna.Text = "12" And ComboFila.Text = "C" Then
    '        ComboColumna.Text = "11"
    '        ComboFila.Text = "D"
    '    ElseIf ComboColumna.Text = "11" And ComboFila.Text = "D" Then
    '        ComboColumna.Text = "12"
    '        ComboFila.Text = "D"
    '    ElseIf ComboColumna.Text = "12" And ComboFila.Text = "D" Then
    '        ComboColumna.Text = "11"
    '        ComboFila.Text = "E"
    '    ElseIf ComboColumna.Text = "11" And ComboFila.Text = "E" Then
    '        ComboColumna.Text = "12"
    '        ComboFila.Text = "E"
    '    ElseIf ComboColumna.Text = "12" And ComboFila.Text = "E" Then
    '        ComboColumna.Text = "11"
    '        ComboFila.Text = "F"
    '    ElseIf ComboColumna.Text = "11" And ComboFila.Text = "F" Then
    '        ComboColumna.Text = "12"
    '        ComboFila.Text = "F"
    '    ElseIf ComboColumna.Text = "12" And ComboFila.Text = "F" Then
    '        ComboColumna.Text = "11"
    '        ComboFila.Text = "G"
    '    ElseIf ComboColumna.Text = "11" And ComboFila.Text = "G" Then
    '        ComboColumna.Text = "12"
    '        ComboFila.Text = "G"
    '    ElseIf ComboColumna.Text = "12" And ComboFila.Text = "G" Then
    '        ComboColumna.Text = "11"
    '        ComboFila.Text = "H"
    '    ElseIf ComboColumna.Text = "11" And ComboFila.Text = "H" Then
    '        ComboColumna.Text = "12"
    '        ComboFila.Text = "H"
    '    ElseIf ComboColumna.Text = "12" And ComboFila.Text = "H" Then
    '        ComboColumna.Text = "1"
    '        ComboFila.Text = "A"
    '    End If
    'End Sub
    Private Sub buscarultimonumero()
        Dim ultimonum As New dUltimoNumero
        ultimonum = ultimonum.buscar
        TextIdGrupal.Text = ultimonum.INHIBIDORES + 1
    End Sub

    Private Sub ComboColumna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboColumna.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            ComboFila.Focus()
        End If
    End Sub

    Private Sub ComboFila_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboFila.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextMuestra.Focus()
        End If
    End Sub

    Private Sub TextMuestra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMuestra.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextFicha.Focus()
        End If
    End Sub

    Private Sub TextFicha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextFicha.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            ComboResultado.Focus()
        End If
    End Sub

    Private Sub ComboResultado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboResultado.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            guardar()
            listarfc()
            listar()
            columnafila()
            TextMuestra.Text = ""
            ComboResultado.Text = "Negativo"
            TextMuestra.Focus()
        End If
    End Sub

    Private Sub guardar()
        Dim idgrupal As Long = TextIdGrupal.Text.Trim
        Dim columna As Integer = ComboColumna.Text.Trim
        Dim fila As String = ComboFila.Text.Trim
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim ficha As String = TextFicha.Text.Trim
        Dim muestra As String = TextMuestra.Text.Trim
        Dim resultado As Integer = 0
        If ComboResultado.Text = "Negativo" Then
            resultado = 0
        Else
            resultado = 1
        End If
        Dim operador As Integer = Usuario.ID

        If TextId.Text.Trim.Length > 0 Then
            Dim inh As New dInhibidores
            Dim id As Long = TextId.Text.Trim
            inh.ID = id
            inh.IDGRUPAL = idgrupal
            inh.COLUMNA = columna
            inh.FILA = fila
            inh.FECHA = fec
            inh.FICHA = ficha
            inh.MUESTRA = muestra
            inh.RESULTADO = resultado
            inh.OPERADOR = operador
            If (inh.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim inh As New dInhibidores
            Dim un As New dUltimoNumero
            un = un.buscar
            If idgrupal > un.INHIBIDORES Then
                inh.IDGRUPAL = idgrupal
                un.INHIBIDORES = idgrupal
                inh.COLUMNA = columna
                inh.FILA = fila
                inh.FECHA = fec
                inh.FICHA = ficha
                inh.MUESTRA = muestra
                inh.RESULTADO = resultado
                inh.OPERADOR = operador
                If (inh.guardar(Usuario)) Then
                    un.modificar()
                    'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                inh.IDGRUPAL = idgrupal
                inh.COLUMNA = columna
                inh.FILA = fila
                inh.FECHA = fec
                inh.FICHA = ficha
                inh.MUESTRA = muestra
                inh.RESULTADO = resultado
                inh.OPERADOR = operador
                If (inh.guardar(Usuario)) Then
                    
                    'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
        End If
        End If
    End Sub
    Private Sub listarfc()
        Dim inh As New dInhibidores
        Dim lista1_2 As New ArrayList
        Dim lista3_4 As New ArrayList
        Dim lista5_6 As New ArrayList
        Dim lista7_8 As New ArrayList
        Dim lista9_10 As New ArrayList
        Dim lista11_12 As New ArrayList
        Dim texto As Long = TextIdGrupal.Text.Trim
        '*****************************************
        lista1_2 = inh.listar1_2(texto)
        List1_2.Items.Clear()
        If Not lista1_2 Is Nothing Then
            If lista1_2.Count > 0 Then
                For Each inh In lista1_2
                    List1_2().Items.Add(inh)
                Next
            End If
        End If
        '*****************************************
        lista3_4 = inh.listar3_4(texto)
        List3_4.Items.Clear()
        If Not lista3_4 Is Nothing Then
            If lista3_4.Count > 0 Then
                For Each inh In lista3_4
                    List3_4().Items.Add(inh)
                Next
            End If
        End If
        '*****************************************
        lista5_6 = inh.listar5_6(texto)
        List5_6.Items.Clear()
        If Not lista5_6 Is Nothing Then
            If lista5_6.Count > 0 Then
                For Each inh In lista5_6
                    List5_6().Items.Add(inh)
                Next
            End If
        End If
        '*****************************************
        lista7_8 = inh.listar7_8(texto)
        List7_8.Items.Clear()
        If Not lista7_8 Is Nothing Then
            If lista7_8.Count > 0 Then
                For Each inh In lista7_8
                    List7_8().Items.Add(inh)
                Next
            End If
        End If
        '*****************************************
        lista9_10 = inh.listar9_10(texto)
        List9_10.Items.Clear()
        If Not lista9_10 Is Nothing Then
            If lista9_10.Count > 0 Then
                For Each inh In lista9_10
                    List9_10().Items.Add(inh)
                Next
            End If
        End If
        '*****************************************
        lista11_12 = inh.listar11_12(texto)
        List11_12.Items.Clear()
        If Not lista11_12 Is Nothing Then
            If lista11_12.Count > 0 Then
                For Each inh In lista11_12
                    List11_12().Items.Add(inh)
                Next
            End If
        End If

    End Sub
    Private Sub listar()
        Dim inh As New dInhibidores
        Dim lista As New ArrayList
        lista = inh.listargrupos
        ListInhibidores.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each inh In lista
                    ListInhibidores().Items.Add(inh)
                Next
            End If
        End If
        
    End Sub

    Private Sub ListInhibidores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListInhibidores.SelectedIndexChanged
        limpiar()
        If ListInhibidores.SelectedItems.Count = 1 Then
            Dim inh As dInhibidores = CType(ListInhibidores.SelectedItem, dInhibidores)
            Dim id As Long = inh.IDGRUPAL
            Dim lista1_2 As New ArrayList
            Dim lista3_4 As New ArrayList
            Dim lista5_6 As New ArrayList
            Dim lista7_8 As New ArrayList
            Dim lista9_10 As New ArrayList
            Dim lista11_12 As New ArrayList
            TextIdGrupal.Text = inh.IDGRUPAL
            '*****************************************
            lista1_2 = inh.listar1_2(id)
            List1_2.Items.Clear()
            If Not lista1_2 Is Nothing Then
                If lista1_2.Count > 0 Then
                    For Each inh In lista1_2
                        List1_2().Items.Add(inh)
                    Next
                End If
            End If
            '*****************************************
            lista3_4 = inh.listar3_4(id)
            List3_4.Items.Clear()
            If Not lista3_4 Is Nothing Then
                If lista3_4.Count > 0 Then
                    For Each inh In lista3_4
                        List3_4().Items.Add(inh)
                    Next
                End If
            End If
            '*****************************************
            lista5_6 = inh.listar5_6(id)
            List5_6.Items.Clear()
            If Not lista5_6 Is Nothing Then
                If lista5_6.Count > 0 Then
                    For Each inh In lista5_6
                        List5_6().Items.Add(inh)
                    Next
                End If
            End If
            '*****************************************
            lista7_8 = inh.listar7_8(id)
            List7_8.Items.Clear()
            If Not lista7_8 Is Nothing Then
                If lista7_8.Count > 0 Then
                    For Each inh In lista7_8
                        List7_8().Items.Add(inh)
                    Next
                End If
            End If
            '*****************************************
            lista9_10 = inh.listar9_10(id)
            List9_10.Items.Clear()
            If Not lista9_10 Is Nothing Then
                If lista9_10.Count > 0 Then
                    For Each inh In lista9_10
                        List9_10().Items.Add(inh)
                    Next
                End If
            End If
            '*****************************************
            lista11_12 = inh.listar11_12(id)
            List11_12.Items.Clear()
            If Not lista11_12 Is Nothing Then
                If lista11_12.Count > 0 Then
                    For Each inh In lista11_12
                        List11_12().Items.Add(inh)
                    Next
                End If
            End If

        End If
    End Sub
   
    Private Sub List1_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List1_2.SelectedIndexChanged
        limpiar()
        If List1_2.SelectedItems.Count = 1 Then
            Dim inh As dInhibidores = CType(List1_2.SelectedItem, dInhibidores)
            DateFecha.Value = inh.FECHA
            TextIdGrupal.Text = inh.IDGRUPAL
            ComboColumna.Text = inh.COLUMNA
            ComboFila.Text = inh.FILA
            TextMuestra.Text = inh.MUESTRA
            TextFicha.Text = inh.FICHA
            If inh.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = inh.ID
        End If
    End Sub
    Private Sub limpiar()
        DateFecha.Value = Now
        'TextIdGrupal.Text = ""
        ComboColumna.Text = ""
        ComboFila.Text = ""
        TextMuestra.Text = ""
        TextFicha.Text = ""
        ComboResultado.Text = ""
        TextId.Text = ""
    End Sub
    Private Sub limpiar2()
        ComboColumna.Text = ""
        ComboFila.Text = ""
        TextMuestra.Text = ""
        TextFicha.Text = ""
        ComboResultado.Text = ""
        TextId.Text = ""
        cargarxdefecto()
    End Sub

    Private Sub List3_4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List3_4.SelectedIndexChanged
        limpiar()
        If List3_4.SelectedItems.Count = 1 Then
            Dim inh As dInhibidores = CType(List3_4.SelectedItem, dInhibidores)
            DateFecha.Value = inh.FECHA
            TextIdGrupal.Text = inh.IDGRUPAL
            ComboColumna.Text = inh.COLUMNA
            ComboFila.Text = inh.FILA
            TextMuestra.Text = inh.MUESTRA
            TextFicha.Text = inh.FICHA
            If inh.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = inh.ID
        End If
    End Sub

    Private Sub List5_6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List5_6.SelectedIndexChanged
        limpiar()
        If List5_6.SelectedItems.Count = 1 Then
            Dim inh As dInhibidores = CType(List5_6.SelectedItem, dInhibidores)
            DateFecha.Value = inh.FECHA
            TextIdGrupal.Text = inh.IDGRUPAL
            ComboColumna.Text = inh.COLUMNA
            ComboFila.Text = inh.FILA
            TextMuestra.Text = inh.MUESTRA
            TextFicha.Text = inh.FICHA
            If inh.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = inh.ID
        End If
    End Sub

    Private Sub List7_8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List7_8.SelectedIndexChanged
        limpiar()
        If List7_8.SelectedItems.Count = 1 Then
            Dim inh As dInhibidores = CType(List7_8.SelectedItem, dInhibidores)
            DateFecha.Value = inh.FECHA
            TextIdGrupal.Text = inh.IDGRUPAL
            ComboColumna.Text = inh.COLUMNA
            ComboFila.Text = inh.FILA
            TextMuestra.Text = inh.MUESTRA
            TextFicha.Text = inh.FICHA
            If inh.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = inh.ID
        End If
    End Sub

    Private Sub List9_10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List9_10.SelectedIndexChanged
        limpiar()
        If List9_10.SelectedItems.Count = 1 Then
            Dim inh As dInhibidores = CType(List9_10.SelectedItem, dInhibidores)
            DateFecha.Value = inh.FECHA
            TextIdGrupal.Text = inh.IDGRUPAL
            ComboColumna.Text = inh.COLUMNA
            ComboFila.Text = inh.FILA
            TextMuestra.Text = inh.MUESTRA
            TextFicha.Text = inh.FICHA
            If inh.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = inh.ID
        End If
    End Sub

    Private Sub List11_12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List11_12.SelectedIndexChanged
        limpiar()
        If List11_12.SelectedItems.Count = 1 Then
            Dim inh As dInhibidores = CType(List11_12.SelectedItem, dInhibidores)
            DateFecha.Value = inh.FECHA
            TextIdGrupal.Text = inh.IDGRUPAL
            ComboColumna.Text = inh.COLUMNA
            ComboFila.Text = inh.FILA
            TextMuestra.Text = inh.MUESTRA
            TextFicha.Text = inh.FICHA
            If inh.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = inh.ID
        End If
    End Sub

    Private Sub ComboResultado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboResultado.SelectedIndexChanged
        If ComboResultado.Text = "Positivo" Then
            MsgBox("Inhibidor positivo!!!", MsgBoxStyle.Information, "Atención")
        End If

    End Sub

    Private Sub ButtonEliminarR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminarR.Click
        If TextId.Text <> "" Then
            Dim inh As New dInhibidores
            Dim id As Long = CType(TextId.Text, Long)
            inh.ID = id
            If (inh.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        listar()
        listarfc()
    End Sub

    Private Sub ButtonFinalizado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFinalizado.Click
        If ListInhibidores.SelectedItems.Count = 1 Then

            'Control de aviso de inhibidores positivos antes de guardar
            Dim id_control As Long = TextIdGrupal.Text.Trim
            Dim inh_control As New dInhibidores
            Dim listacontrol As New ArrayList
            listacontrol = inh_control.listarporidgrupal(id_control)
            Dim texto As String = ""
            If Not listacontrol Is Nothing Then
                If listacontrol.Count > 0 Then
                    For Each inh_control In listacontrol
                        If inh_control.RESULTADO = 1 Then
                            texto = texto & "fila: " & inh_control.FILA & " columna: " & inh_control.COLUMNA & " - "

                        End If
                    Next
                End If
            End If
            If texto <> "" Then
                texto = texto & "Inhibidores positivos, "
                Dim result = MessageBox.Show(texto & "desea continuar?", "Atención!", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Cancel Then
                    Exit Sub
                ElseIf result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                   
                End If

            End If
            '*************************************************************



            Dim inh As dInhibidores = CType(ListInhibidores.SelectedItem, dInhibidores)
            Dim id As Long = inh.IDGRUPAL
            inh.marcar(id, Usuario)
            Dim inh2 As New dInhibidores

            Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")

            Dim lista As New ArrayList
            lista = inh2.listarporidgrupal(id)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each inh2 In lista
                        If inh2.RESULTADO = 1 Then
                            Dim inhc As New dInhibidoresControl
                            inhc.FICHA = inh2.FICHA
                            inhc.MUESTRA = inh2.MUESTRA
                            inhc.RESULTADO = inh2.RESULTADO
                            inhc.FECHA = fec
                            inhc.OPERADOR = 0
                            inhc.MARCA = 0
                            inhc.guardar(Usuario)
                        End If
                    Next
                End If
            End If
        End If
        listar()
        listarfc()
        List1_2.Items.Clear()
        List3_4.Items.Clear()
        List5_6.Items.Clear()
        List7_8.Items.Clear()
        List9_10.Items.Clear()
        List11_12.Items.Clear()
        buscarultimonumero()
    End Sub

    Private Sub ButtonAgregarR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar2()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        List1_2.Items.Clear()
        List3_4.Items.Clear()
        List5_6.Items.Clear()
        List7_8.Items.Clear()
        List9_10.Items.Clear()
        List11_12.Items.Clear()
        buscarultimonumero()
        cargarxdefecto()
        TextMuestra.Focus()
    End Sub
    Private Sub columnafila()
        If ComboColumna.Text = "1" And ComboFila.Text = "A" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "1" And ComboFila.Text = "B" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "1" And ComboFila.Text = "C" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "1" And ComboFila.Text = "D" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "1" And ComboFila.Text = "E" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "1" And ComboFila.Text = "F" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "G"
        ElseIf ComboColumna.Text = "1" And ComboFila.Text = "G" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "H"
        ElseIf ComboColumna.Text = "1" And ComboFila.Text = "H" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "A" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "B" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "C" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "D" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "E" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "F" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "G"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "G" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "H"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "H" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "A"
            '************************************************************
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "A" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "B" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "C" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "D" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "E" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "F" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "G"
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "G" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "H"
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "H" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "A" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "B" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "C" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "D" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "E" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "F" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "G"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "G" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "H"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "H" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "A"
            '************************************************************
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "A" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "B" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "C" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "D" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "E" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "F" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "G"
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "G" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "H"
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "H" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "A" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "B" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "C" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "D" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "E" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "F" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "G"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "G" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "H"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "H" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "A"
            '************************************************************
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "A" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "B" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "C" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "D" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "E" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "F" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "G"
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "G" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "H"
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "H" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "A" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "B" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "C" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "D" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "E" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "F" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "G"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "G" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "H"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "H" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "A"
            '************************************************************
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "A" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "B" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "C" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "D" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "E" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "F" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "G"
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "G" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "H"
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "H" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "A" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "B" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "C" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "D" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "E" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "F" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "G"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "G" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "H"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "H" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "A"
            '************************************************************
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "A" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "B" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "C" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "D" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "E" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "F" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "G"
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "G" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "H"
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "H" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "A" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "B" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "C" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "D" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "E" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "F" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "G"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "G" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "H"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "H" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "A"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim v As New FormInhibidores_obs()
        v.ShowDialog()
    End Sub

    Private Sub TextId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextId.TextChanged

    End Sub
End Class