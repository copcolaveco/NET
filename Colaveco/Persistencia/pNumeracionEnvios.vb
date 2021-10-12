Public Class pNumeracionEnvios
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNumeracionEnvios = CType(o, dNumeracionEnvios)
        Dim sql As String = "INSERT INTO numeracionenvios (id, idagencia, envio) VALUES (" & obj.ID & ", " & obj.IDAGENCIA & ", '" & obj.ENVIO & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'numeracionenvios', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNumeracionEnvios = CType(o, dNumeracionEnvios)
        Dim sql As String = "UPDATE numeracionenvios SET idagencia = " & obj.IDAGENCIA & ", envio = '" & obj.ENVIO & "' WHERE idagencia = " & obj.IDAGENCIA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'numeracionenvios', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNumeracionEnvios = CType(o, dNumeracionEnvios)
        Dim sql As String = "DELETE FROM numeracionenvios WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'numeracionenvios', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dNumeracionEnvios
        Dim obj As dNumeracionEnvios = CType(o, dNumeracionEnvios)
        Dim l As New dNumeracionEnvios
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idagencia, envio FROM numeracionenvios WHERE idagencia = " & obj.IDAGENCIA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.IDAGENCIA = CType(unaFila.Item(1), Integer)
                l.ENVIO = CType(unaFila.Item(2), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idagencia, envio FROM numeracionenvios order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dNumeracionEnvios
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.IDAGENCIA = CType(unaFila.Item(1), Integer)
                    l.ENVIO = CType(unaFila.Item(2), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
