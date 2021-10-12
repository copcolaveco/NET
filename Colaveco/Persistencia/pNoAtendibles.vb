Public Class pNoAtendibles
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNoAtendibles = CType(o, dNoAtendibles)
        Dim sql As String = "INSERT INTO no_atendibles (id, fecha, cliente, telefono, analisis, cantidad, observaciones, usuario) VALUES (" & obj.ID & ", '" & obj.FECHA & "', '" & obj.CLIENTE & "','" & obj.TELEFONO & "', '" & obj.ANALISIS & "','" & obj.CANTIDAD & "', '" & obj.OBSERVACIONES & "', " & obj.USUARIO & " )"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'no_atendibles', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNoAtendibles = CType(o, dNoAtendibles)
        Dim sql As String = "UPDATE no_atendibles SET fecha ='" & obj.FECHA & "', cliente = '" & obj.CLIENTE & "', telefono ='" & obj.TELEFONO & "', analisis = '" & obj.ANALISIS & "', cantidad ='" & obj.CANTIDAD & "', observaciones= '" & obj.OBSERVACIONES & "', usuario= " & obj.USUARIO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'no_atendibles', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNoAtendibles = CType(o, dNoAtendibles)
        Dim sql As String = "DELETE FROM no_atendibles WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'no_atendibles', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dNoAtendibles
        Dim obj As dNoAtendibles = CType(o, dNoAtendibles)
        Dim p As New dNoAtendibles
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, ifnull(cliente,''), ifnull(telefono,''), ifnull(analisis,''), ifnull(cantidad,''), ifnull(observaciones,''), usuario FROM no_atendibles WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FECHA = CType(unaFila.Item(1), String)
                p.CLIENTE = CType(unaFila.Item(2), String)
                p.TELEFONO = CType(unaFila.Item(3), String)
                p.ANALISIS = CType(unaFila.Item(4), String)
                p.CANTIDAD = CType(unaFila.Item(5), String)
                p.OBSERVACIONES = CType(unaFila.Item(6), String)
                p.USUARIO = CType(unaFila.Item(7), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, ifnull(cliente,''), ifnull(telefono,''), ifnull(analisis,''), ifnull(cantidad,''), ifnull(observaciones,''), usuario FROM no_atendibles ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dNoAtendibles
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.CLIENTE = CType(unaFila.Item(2), String)
                    p.TELEFONO = CType(unaFila.Item(3), String)
                    p.ANALISIS = CType(unaFila.Item(4), String)
                    p.CANTIDAD = CType(unaFila.Item(5), String)
                    p.OBSERVACIONES = CType(unaFila.Item(6), String)
                    p.USUARIO = CType(unaFila.Item(7), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
