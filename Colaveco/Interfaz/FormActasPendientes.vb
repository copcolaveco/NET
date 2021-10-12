Public Class FormActasPendientes
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
        DateFecha.Value = Now
        cargarGrupos()
        ComboGrupo.Text = "General"
        listartodospendientes()
        RadioTodosPendientes.Checked = True
        'listartodos()
        'RadioTodos.Checked = True
    End Sub

#End Region
    Public Sub cargarGrupos()
        Dim s As New dSectores
        Dim lista As New ArrayList
        lista = s.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ComboGrupo.Items.Add(s)
                Next
            End If
        End If
    End Sub
    Public Sub listartodos()
        Dim ai As New dActasItem
        Dim lista As New ArrayList
        lista = ai.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ai In lista
                    DataGridView1(columna, fila).Value = ai.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.IDACTA
                    columna = columna + 1
                    Dim a As New dActas
                    a.ID = ai.IDACTA
                    a = a.buscar
                    DataGridView1(columna, fila).Value = a.NUMERO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.FECHA
                    columna = columna + 1
                    Dim s As New dSectores
                    s.ID = a.GRUPO
                    s = s.buscar
                    DataGridView1(columna, fila).Value = s.NOMBRE
                    columna = columna + 1
                    a = Nothing
                    s = Nothing
                    DataGridView1(columna, fila).Value = ai.TEMA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.RESUMEN
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.RESPONSABLES
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.PLAZO
                    If ai.EFECTUADO = 0 Then
                        If ai.PLAZO < Now Then
                            DataGridView1(columna, fila).Style.BackColor = Color.Red
                            DataGridView1(columna, fila).Style.ForeColor = Color.White
                        Else
                            DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                            DataGridView1(columna, fila).Style.ForeColor = Color.Black
                        End If
                    Else
                        DataGridView1(columna, fila).Style.BackColor = Color.Green
                        DataGridView1(columna, fila).Style.ForeColor = Color.Black
                    End If
                    columna = 0
                    fila = fila + 1

                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Public Sub listartodospendientes()
        Dim ai As New dActasItem
        Dim lista As New ArrayList
        lista = ai.listarpendientes
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ai In lista
                    DataGridView1(columna, fila).Value = ai.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.IDACTA
                    columna = columna + 1
                    Dim a As New dActas
                    a.ID = ai.IDACTA
                    a = a.buscar
                    DataGridView1(columna, fila).Value = a.NUMERO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.FECHA
                    columna = columna + 1
                    Dim s As New dSectores
                    s.ID = a.GRUPO
                    s = s.buscar
                    DataGridView1(columna, fila).Value = s.NOMBRE
                    columna = columna + 1
                    a = Nothing
                    s = Nothing
                    DataGridView1(columna, fila).Value = ai.TEMA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.RESUMEN
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.RESPONSABLES
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.PLAZO
                    If ai.PLAZO < Now Then
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    Else
                        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        DataGridView1(columna, fila).Style.ForeColor = Color.Black
                    End If
                   
                    columna = 0
                    fila = fila + 1

                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub listarvencidos()
        Dim ai As New dActasItem
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim lista As New ArrayList
        lista = ai.listarvencidos(fec)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ai In lista
                    DataGridView1(columna, fila).Value = ai.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.IDACTA
                    columna = columna + 1
                    Dim a As New dActas
                    a.ID = ai.IDACTA
                    a = a.buscar
                    DataGridView1(columna, fila).Value = a.NUMERO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.FECHA
                    columna = columna + 1
                    Dim s As New dSectores
                    s.ID = a.GRUPO
                    s = s.buscar
                    DataGridView1(columna, fila).Value = s.NOMBRE
                    columna = columna + 1
                    a = Nothing
                    s = Nothing
                    DataGridView1(columna, fila).Value = ai.TEMA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.RESUMEN
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.RESPONSABLES
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.PLAZO
                    If ai.PLAZO < Now Then
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                    End If
                    columna = 0
                    fila = fila + 1

                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub listarefectuados()
        Dim ai As New dActasItem
        Dim lista As New ArrayList
        lista = ai.listarefectuados
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each ai In lista
                    DataGridView1(columna, fila).Value = ai.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.IDACTA
                    columna = columna + 1
                    Dim a As New dActas
                    a.ID = ai.IDACTA
                    a = a.buscar
                    DataGridView1(columna, fila).Value = a.NUMERO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.FECHA
                    columna = columna + 1
                    Dim s As New dSectores
                    s.ID = a.GRUPO
                    s = s.buscar
                    DataGridView1(columna, fila).Value = s.NOMBRE
                    columna = columna + 1
                    a = Nothing
                    s = Nothing
                    DataGridView1(columna, fila).Value = ai.TEMA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.RESUMEN
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.RESPONSABLES
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ai.PLAZO
                    DataGridView1(columna, fila).Style.BackColor = Color.Green
                    DataGridView1(columna, fila).Style.ForeColor = Color.Black
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub listarefectuadosxgrupo()
        Dim a As New dActas
        Dim listaaactas As New ArrayList
        Dim idgrupo As dSectores = CType(ComboGrupo.SelectedItem, dSectores)
        listaaactas = a.listarxgrupo(idgrupo.ID)
        If Not listaaactas Is Nothing Then
            If listaaactas.Count > 0 Then
                Dim ai As New dActasItem
                Dim lista As New ArrayList
                Dim idacta As Long = 0
                Dim numacta As String = ""
                Dim fechaacta As String = ""
                Dim grupo As Integer = 0
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Clear()
                For Each a In listaaactas
                    idacta = a.ID
                    numacta = a.NUMERO
                    fechaacta = a.FECHA
                    grupo = a.GRUPO
                    lista = ai.listarefectuadosxgrupo(idacta)

                    If Not lista Is Nothing Then
                        If lista.Count > 0 Then
                            DataGridView1.Rows.Add(lista.Count)
                            For Each ai In lista
                                DataGridView1(columna, fila).Value = ai.ID
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.IDACTA
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = numacta
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = fechaacta
                                columna = columna + 1
                                Dim s As New dSectores
                                s.ID = grupo
                                s = s.buscar
                                DataGridView1(columna, fila).Value = s.NOMBRE
                                columna = columna + 1
                                s = Nothing
                                DataGridView1(columna, fila).Value = ai.TEMA
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.RESUMEN
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.RESPONSABLES
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.PLAZO
                                If ai.EFECTUADO = 0 Then
                                    If ai.PLAZO < Now Then
                                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                                    Else
                                        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                                        DataGridView1(columna, fila).Style.ForeColor = Color.Black
                                    End If
                                Else
                                    DataGridView1(columna, fila).Style.BackColor = Color.Green
                                    DataGridView1(columna, fila).Style.ForeColor = Color.Black
                                End If
                                columna = 0
                                fila = fila + 1
                            Next
                        End If
                    End If
                Next
        'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub listartodosxgrupo()
        Dim a As New dActas
        Dim listaaactas As New ArrayList
        Dim idgrupo As dSectores = CType(ComboGrupo.SelectedItem, dSectores)
        listaaactas = a.listarxgrupo(idgrupo.ID)
        If Not listaaactas Is Nothing Then
            If listaaactas.Count > 0 Then
                Dim ai As New dActasItem
                Dim lista As New ArrayList
                Dim idacta As Long = 0
                Dim numacta As String = ""
                Dim fechaacta As String = ""
                Dim grupo As Integer = 0
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Clear()
                For Each a In listaaactas
                    idacta = a.ID
                    numacta = a.NUMERO
                    fechaacta = a.FECHA
                    grupo = a.GRUPO
                    lista = ai.listartodosxgrupo(idacta)

                    If Not lista Is Nothing Then
                        If lista.Count > 0 Then
                            DataGridView1.Rows.Add(lista.Count)
                            For Each ai In lista
                                DataGridView1(columna, fila).Value = ai.ID
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.IDACTA
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = numacta
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = fechaacta
                                columna = columna + 1
                                Dim s As New dSectores
                                s.ID = grupo
                                s = s.buscar
                                DataGridView1(columna, fila).Value = s.NOMBRE
                                columna = columna + 1
                                s = Nothing
                                DataGridView1(columna, fila).Value = ai.TEMA
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.RESUMEN
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.RESPONSABLES
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.PLAZO
                                If ai.EFECTUADO = 0 Then
                                    If ai.PLAZO < Now Then
                                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                                    Else
                                        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                                        DataGridView1(columna, fila).Style.ForeColor = Color.Black
                                    End If
                                Else
                                    DataGridView1(columna, fila).Style.BackColor = Color.Green
                                    DataGridView1(columna, fila).Style.ForeColor = Color.Black
                                End If
                                columna = 0
                                fila = fila + 1
                            Next
                        End If
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub listarpendientesxgrupo()
        Dim a As New dActas
        Dim listaaactas As New ArrayList
        Dim idgrupo As dSectores = CType(ComboGrupo.SelectedItem, dSectores)
        listaaactas = a.listarxgrupo(idgrupo.ID)
        If Not listaaactas Is Nothing Then
            If listaaactas.Count > 0 Then
                Dim ai As New dActasItem
                Dim lista As New ArrayList
                Dim idacta As Long = 0
                Dim numacta As String = ""
                Dim fechaacta As String = ""
                Dim grupo As Integer = 0
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Clear()
                For Each a In listaaactas
                    idacta = a.ID
                    numacta = a.NUMERO
                    fechaacta = a.FECHA
                    grupo = a.GRUPO
                    lista = ai.listarpendientesxgrupo(idacta)

                    If Not lista Is Nothing Then
                        If lista.Count > 0 Then
                            DataGridView1.Rows.Add(lista.Count)
                            For Each ai In lista
                                DataGridView1(columna, fila).Value = ai.ID
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.IDACTA
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = numacta
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = fechaacta
                                columna = columna + 1
                                Dim s As New dSectores
                                s.ID = grupo
                                s = s.buscar
                                DataGridView1(columna, fila).Value = s.NOMBRE
                                columna = columna + 1
                                s = Nothing
                                DataGridView1(columna, fila).Value = ai.TEMA
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.RESUMEN
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.RESPONSABLES
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.PLAZO
                                If ai.PLAZO < Now Then
                                    DataGridView1(columna, fila).Style.BackColor = Color.Red
                                    DataGridView1(columna, fila).Style.ForeColor = Color.White
                                Else
                                    DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                                    DataGridView1(columna, fila).Style.ForeColor = Color.Black
                                End If
                                columna = 0
                                fila = fila + 1
                            Next
                        End If
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub listarvencidosxgrupo()
        Dim a As New dActas
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim listaaactas As New ArrayList
        Dim idgrupo As dSectores = CType(ComboGrupo.SelectedItem, dSectores)
        listaaactas = a.listarxgrupo(idgrupo.ID)
        If Not listaaactas Is Nothing Then
            If listaaactas.Count > 0 Then
                Dim ai As New dActasItem
                Dim lista As New ArrayList
                Dim idacta As Long = 0
                Dim numacta As String = ""
                Dim fechaacta As String = ""
                Dim grupo As Integer = 0
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Clear()
                For Each a In listaaactas
                    idacta = a.ID
                    numacta = a.NUMERO
                    fechaacta = a.FECHA
                    grupo = a.GRUPO
                    lista = ai.listarvencidosxgrupo(idacta, fec)

                    If Not lista Is Nothing Then
                        If lista.Count > 0 Then
                            DataGridView1.Rows.Add(lista.Count)
                            For Each ai In lista
                                DataGridView1(columna, fila).Value = ai.ID
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.IDACTA
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = numacta
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = fechaacta
                                columna = columna + 1
                                Dim s As New dSectores
                                s.ID = grupo
                                s = s.buscar
                                DataGridView1(columna, fila).Value = s.NOMBRE
                                columna = columna + 1
                                s = Nothing
                                DataGridView1(columna, fila).Value = ai.TEMA
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.RESUMEN
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.RESPONSABLES
                                columna = columna + 1
                                DataGridView1(columna, fila).Value = ai.PLAZO
                                DataGridView1(columna, fila).Style.BackColor = Color.Red
                                DataGridView1(columna, fila).Style.ForeColor = Color.White
                                columna = 0
                                fila = fila + 1
                            Next
                        End If
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub RadioTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioTodosPendientes.CheckedChanged
        listar()
    End Sub

    Private Sub RadioVencidos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioVencidos.CheckedChanged
        listar()
    End Sub

    Private Sub RadioEfectuados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEfectuados.CheckedChanged
        listar()
    End Sub

    Private Sub RadioTodos_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioTodos.CheckedChanged
        listar()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Efectuada" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id").Value
            Dim ai As New dActasItem
            ai.ID = id
            ai.marcarefectuada(Usuario)

            If ComboGrupo.Text = "General" Then
                If RadioTodos.Checked = True Then
                    listartodos()
                ElseIf RadioTodosPendientes.Checked = True Then
                    listartodospendientes()
                ElseIf RadioVencidos.Checked = True Then
                    listarvencidos()
                Else
                    listarefectuados()
                End If
            Else
                If RadioTodos.Checked = True Then
                    listartodosxgrupo()
                ElseIf RadioTodosPendientes.Checked = True Then
                    listarpendientesxgrupo()
                ElseIf RadioVencidos.Checked = True Then
                    listarvencidosxgrupo()
                Else
                    listarefectuadosxgrupo()
                End If
            End If

        End If
    End Sub

    Private Sub ComboGrupo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboGrupo.SelectedIndexChanged
        listar()
       
    End Sub

    Private Sub listar()
        If ComboGrupo.Text = "General" Then
            If RadioTodos.Checked = True Then
                listartodos()
            ElseIf RadioTodosPendientes.Checked = True Then
                listartodospendientes()
            ElseIf RadioVencidos.Checked = True Then
                listarvencidos()
            Else
                listarefectuados()
            End If
        Else
            If RadioTodos.Checked = True Then
                listartodosxgrupo()
            ElseIf RadioTodosPendientes.Checked = True Then
                listarpendientesxgrupo()
            ElseIf RadioVencidos.Checked = True Then
                listarvencidosxgrupo()
            Else
                listarefectuadosxgrupo()
            End If
        End If
    End Sub
End Class