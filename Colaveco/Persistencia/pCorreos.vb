Public Class pCorreos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCorreos = CType(o, dCorreos)
        Dim sql As String = "INSERT INTO correos (id, ficha, informe, cliente, email, texto, adjunto, enviado) VALUES (" & obj.ID & ", " & obj.FICHA & ", '" & obj.INFORME & "', '" & obj.CLIENTE & "', '" & obj.EMAIL & "', '" & obj.TEXTO & "', '" & obj.ADJUNTO & "', " & obj.ENVIADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'correos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCorreos = CType(o, dCorreos)
        Dim sql As String = "UPDATE correos SET ficha = " & obj.FICHA & ", informe = '" & obj.INFORME & "', cliente = '" & obj.CLIENTE & "', email = '" & obj.EMAIL & "', texto = '" & obj.TEXTO & "', adjunto = '" & obj.ADJUNTO & "', enviado = " & obj.ENVIADO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'correos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCorreos = CType(o, dCorreos)
        Dim sql As String = "DELETE FROM correos WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'correos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCorreos
        Dim obj As dCorreos = CType(o, dCorreos)
        Dim p As New dCorreos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, informe, cliente, email, texto, adjunto, enviado FROM correos WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FICHA = CType(unaFila.Item(1), Long)
                p.INFORME = CType(unaFila.Item(2), String)
                p.CLIENTE = CType(unaFila.Item(3), String)
                p.EMAIL = CType(unaFila.Item(4), String)
                p.TEXTO = CType(unaFila.Item(5), String)
                p.ADJUNTO = CType(unaFila.Item(6), String)
                p.ENVIADO = CType(unaFila.Item(7), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, informe, cliente, email, texto, adjunto, enviado ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCorreos
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.INFORME = CType(unaFila.Item(2), String)
                    p.CLIENTE = CType(unaFila.Item(3), String)
                    p.EMAIL = CType(unaFila.Item(4), String)
                    p.TEXTO = CType(unaFila.Item(5), String)
                    p.ADJUNTO = CType(unaFila.Item(6), String)
                    p.ENVIADO = CType(unaFila.Item(7), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


End Class
