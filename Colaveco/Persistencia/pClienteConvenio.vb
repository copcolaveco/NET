Public Class pClienteConvenio
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dClienteConvenio = CType(o, dClienteConvenio)
        Dim sql As String = "INSERT INTO clienteconvenio (id, cliente, convenio) VALUES (" & obj.ID & ", " & obj.CLIENTE & ", " & obj.CONVENIO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'clienteconvenio', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dClienteConvenio = CType(o, dClienteConvenio)
        Dim sql As String = "UPDATE clienteconvenio SET cliente = " & obj.CLIENTE & ", convenio = " & obj.CONVENIO & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'clienteconvenio', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dClienteConvenio = CType(o, dClienteConvenio)
        Dim sql As String = "DELETE FROM clienteconvenio WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'clienteconvenio', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dClienteConvenio
        Dim obj As dClienteConvenio = CType(o, dClienteConvenio)
        Dim l As New dClienteConvenio
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, cliente, convenio FROM clienteconvenio WHERE ID = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.CLIENTE = CType(unaFila.Item(1), Integer)
                l.CONVENIO = CType(unaFila.Item(2), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, cliente, convenio FROM clienteconvenio"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dClienteConvenio
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.CLIENTE = CType(unaFila.Item(1), Integer)
                    l.CONVENIO = CType(unaFila.Item(2), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporcliente(ByVal texto As Integer) As ArrayList
        Dim sql As String = ("SELECT id, cliente, convenio FROM clienteconvenio where cliente = " & texto & " ")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dClienteConvenio
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.CLIENTE = CType(unaFila.Item(1), Integer)
                    l.CONVENIO = CType(unaFila.Item(2), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
