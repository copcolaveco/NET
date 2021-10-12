Public Class pProductorEmpresa
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProductorEmpresa = CType(o, dProductorEmpresa)
        Dim sql As String = "INSERT INTO productorempresa (id, idproductor, matricula, idempresa) VALUES (" & obj.ID & ", " & obj.IDPRODUCTOR & ", '" & obj.MATRICULA & "', " & obj.IDEMPRESA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'productorempresa', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProductorEmpresa = CType(o, dProductorEmpresa)
        Dim sql As String = "UPDATE productorempresa SET idproductor = " & obj.IDPRODUCTOR & ", matricula = '" & obj.MATRICULA & "',idempresa = " & obj.IDEMPRESA & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'productorempresa', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProductorEmpresa = CType(o, dProductorEmpresa)
        Dim sql As String = "DELETE FROM productorempresa WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'productorempresa', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dProductorEmpresa
        Dim obj As dProductorEmpresa = CType(o, dProductorEmpresa)
        Dim l As New dProductorEmpresa
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idproductor, matricula, idempresa FROM productorempresa WHERE ID = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.IDPRODUCTOR = CType(unaFila.Item(1), Long)
                l.MATRICULA = CType(unaFila.Item(2), String)
                l.IDEMPRESA = CType(unaFila.Item(3), Long)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT  id, idproductor, matricula, idempresa FROM productorempresa order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dProductorEmpresa
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDPRODUCTOR = CType(unaFila.Item(1), Long)
                    l.MATRICULA = CType(unaFila.Item(2), String)
                    l.IDEMPRESA = CType(unaFila.Item(3), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxid(ByVal idprod As Long) As ArrayList
        Dim sql As String = "SELECT  id, idproductor, matricula, idempresa FROM productorempresa WHERE idproductor = " & idprod & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dProductorEmpresa
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDPRODUCTOR = CType(unaFila.Item(1), Long)
                    l.MATRICULA = CType(unaFila.Item(2), String)
                    l.IDEMPRESA = CType(unaFila.Item(3), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxempresa(ByVal idemp As Long) As ArrayList
        Dim sql As String = "SELECT  id, idproductor, matricula, idempresa FROM productorempresa WHERE idempresa = " & idemp & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dProductorEmpresa
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDPRODUCTOR = CType(unaFila.Item(1), Long)
                    l.MATRICULA = CType(unaFila.Item(2), String)
                    l.IDEMPRESA = CType(unaFila.Item(3), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarproductorempresa(ByVal empresa As Long, ByVal matricula As String) As ArrayList
        Dim sql As String = "SELECT  id, idproductor, matricula, idempresa FROM productorempresa WHERE idempresa = " & empresa & " AND matricula = '" & matricula & "' "
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dProductorEmpresa
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDPRODUCTOR = CType(unaFila.Item(1), Long)
                    l.MATRICULA = CType(unaFila.Item(2), String)
                    l.IDEMPRESA = CType(unaFila.Item(3), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarproductorempresa2(ByVal o As Object) As dProductorEmpresa
        Dim obj As dProductorEmpresa = CType(o, dProductorEmpresa)
        Dim l As New dProductorEmpresa
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idproductor, matricula, idempresa FROM productorempresa WHERE idempresa = " & obj.IDEMPRESA & " AND matricula = '" & obj.MATRICULA & "' ")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.IDPRODUCTOR = CType(unaFila.Item(1), Long)
                l.MATRICULA = CType(unaFila.Item(2), String)
                l.IDEMPRESA = CType(unaFila.Item(3), Long)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
