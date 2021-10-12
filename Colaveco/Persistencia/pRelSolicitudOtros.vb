Public Class pRelSolicitudOtros
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRelSolicitudOtros = CType(o, dRelSolicitudOtros)
        Dim sql As String = "INSERT INTO solicitud_otros (id, ficha, descripcion) VALUES (" & obj.ID & ", '" & obj.FICHA & "', '" & obj.DESCRIPCION & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_otros', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRelSolicitudOtros = CType(o, dRelSolicitudOtros)
        Dim sql As String = "UPDATE solicitud_otros SET ficha = '" & obj.FICHA & "', descripcion = '" & obj.DESCRIPCION & "' WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_otros', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRelSolicitudOtros = CType(o, dRelSolicitudOtros)
        Dim sql As String = "DELETE FROM solicitud_otros WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_otros', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dRelSolicitudOtros
        Dim obj As dRelSolicitudOtros = CType(o, dRelSolicitudOtros)
        Dim l As New dRelSolicitudOtros
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, descripcion FROM solicitud_otros WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.FICHA = CType(unaFila.Item(1), String)
                l.DESCRIPCION = CType(unaFila.Item(2), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, descripcion FROM solicitud_otros"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dRelSolicitudOtros
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FICHA = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha(ByVal ficha As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, descripcion FROM solicitud_otros WHERE ficha = " & ficha & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dRelSolicitudOtros
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FICHA = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
