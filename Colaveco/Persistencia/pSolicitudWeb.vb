Public Class pSolicitudWeb
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudWeb = CType(o, dSolicitudWeb)
        Dim sql As String = "INSERT INTO solicitud_web (id, ficha, gestor) VALUES (" & obj.ID & ", " & obj.FICHA & ", " & obj.GESTOR & " )"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_web', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudWeb = CType(o, dSolicitudWeb)
        Dim sql As String = "UPDATE solicitud_web SET ficha = " & obj.FICHA & ", gestor= " & obj.GESTOR & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_web', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudWeb = CType(o, dSolicitudWeb)
        Dim sql As String = "DELETE FROM solicitud_web WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_web', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dSolicitudWeb
        Dim obj As dSolicitudWeb = CType(o, dSolicitudWeb)
        Dim s As New dSolicitudWeb
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, gestor FROM solicitud_web WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Long)
                s.FICHA = CType(unaFila.Item(1), Long)
                s.GESTOR = CType(unaFila.Item(2), Integer)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcarcargado(ByVal o As Object) As Boolean
        Dim obj As dSolicitudWeb = CType(o, dSolicitudWeb)
        Dim sql As String = "UPDATE solicitud_web SET gestor= 1 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, gestor FROM solicitud_web"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudWeb
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FICHA = CType(unaFila.Item(1), Long)
                    s.GESTOR = CType(unaFila.Item(2), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsincargar() As ArrayList
        Dim sql As String = "SELECT id, ficha, gestor FROM solicitud_web WHERE gestor = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudWeb
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FICHA = CType(unaFila.Item(1), Long)
                    s.GESTOR = CType(unaFila.Item(2), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
