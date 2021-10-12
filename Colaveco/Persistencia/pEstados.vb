Public Class pEstados
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEstados = CType(o, dEstados)
        Dim sql As String = "INSERT INTO estados (id, ficha, estado, fecha) VALUES (" & obj.ID & ", " & obj.FICHA & ", " & obj.ESTADO & ", '" & obj.FECHA & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'estados', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function guardar2(ByVal o As Object) As Boolean
        Dim obj As dEstados = CType(o, dEstados)
        Dim sql As String = "INSERT INTO estados (id, ficha, estado, fecha) VALUES (" & obj.ID & ", " & obj.FICHA & ", " & obj.ESTADO & ", '" & obj.FECHA & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'estados', 'alta', last_insert_id(), " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEstados = CType(o, dEstados)
        Dim sql As String = "UPDATE estados SET ficha = " & obj.FICHA & ",estado= " & obj.ESTADO & ",fecha= '" & obj.FECHA & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'estados', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEstados = CType(o, dEstados)
        Dim sql As String = "DELETE FROM estados WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'estados', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dEstados
        Dim obj As dEstados = CType(o, dEstados)
        Dim p As New dEstados
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, estado, fecha FROM estados WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FICHA = CType(unaFila.Item(1), Long)
                p.ESTADO = CType(unaFila.Item(2), Integer)
                p.FECHA = CType(unaFila.Item(3), String)

                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimo(ByVal o As Object) As dEstados
        Dim obj As dEstados = CType(o, dEstados)
        Dim p As New dEstados
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, estado, fecha FROM estados WHERE ficha = " & obj.FICHA & " ORDER BY id DESC")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FICHA = CType(unaFila.Item(1), Long)
                p.ESTADO = CType(unaFila.Item(2), Integer)
                p.FECHA = CType(unaFila.Item(3), String)

                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, estado, fecha FROM estados ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dEstados
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.ESTADO = CType(unaFila.Item(2), Integer)
                    p.FECHA = CType(unaFila.Item(3), String)

                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
   
    
End Class
