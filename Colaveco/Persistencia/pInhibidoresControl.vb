Public Class pInhibidoresControl
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dInhibidoresControl = CType(o, dInhibidoresControl)
        Dim sql As String = "INSERT INTO inhibidores_control (id, ficha, muestra, resultado, fecha, operador, marca) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.MUESTRA & "'," & obj.RESULTADO & ",'" & obj.FECHA & "', " & obj.OPERADOR & ", " & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'inhibidores_control', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dInhibidoresControl = CType(o, dInhibidoresControl)
        Dim sql As String = "UPDATE inhibidores_control SET  ficha = " & obj.FICHA & ", muestra='" & obj.MUESTRA & "', resultado=" & obj.RESULTADO & ", fecha = '" & obj.FECHA & "', operador = " & obj.OPERADOR & ", marca = " & obj.MARCA & " WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "' "

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'inhibidores_control', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dInhibidoresControl = CType(o, dInhibidoresControl)
        Dim sql As String = "DELETE FROM inhibidores_control WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'inhibidores_control', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dInhibidoresControl
        Dim obj As dInhibidoresControl = CType(o, dInhibidoresControl)
        Dim c As New dInhibidoresControl
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id,  ficha, muestra, resultado, fecha,  operador, marca FROM inhibidores_control WHERE ficha = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FICHA = CType(unaFila.Item(1), Long)
                c.MUESTRA = CType(unaFila.Item(2), String)
                c.RESULTADO = CType(unaFila.Item(3), Integer)
                c.FECHA = CType(unaFila.Item(4), String)
                c.OPERADOR = CType(unaFila.Item(5), Integer)
                c.MARCA = CType(unaFila.Item(6), Integer)

                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dInhibidoresControl
        Dim obj As dInhibidoresControl = CType(o, dInhibidoresControl)
        Dim c As New dInhibidoresControl
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id,  ficha, muestra, resultado, fecha,  operador, marca FROM inhibidores_control WHERE ficha = '" & obj.FICHA & "' and muestra='" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FICHA = CType(unaFila.Item(1), Long)
                c.MUESTRA = CType(unaFila.Item(2), String)
                c.RESULTADO = CType(unaFila.Item(3), Integer)
                c.FECHA = CType(unaFila.Item(4), String)
                c.OPERADOR = CType(unaFila.Item(5), Integer)
                c.MARCA = CType(unaFila.Item(6), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id,  ficha, muestra, resultado, fecha,  operador, marca FROM inhibidores_control order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dInhibidoresControl
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.RESULTADO = CType(unaFila.Item(3), Integer)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.OPERADOR = CType(unaFila.Item(5), Integer)
                    c.MARCA = CType(unaFila.Item(6), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinmarca() As ArrayList
        Dim sql As String = "SELECT id,  ficha, muestra, resultado, fecha,  operador, marca FROM inhibidores_control WHERE marca = 0 AND resultado=1 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dInhibidoresControl
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.RESULTADO = CType(unaFila.Item(3), Integer)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.OPERADOR = CType(unaFila.Item(5), Integer)
                    c.MARCA = CType(unaFila.Item(6), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id,  ficha, muestra, resultado, fecha,  operador, marca FROM inhibidores_control where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dInhibidoresControl
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.RESULTADO = CType(unaFila.Item(3), Integer)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.OPERADOR = CType(unaFila.Item(5), Integer)
                    c.MARCA = CType(unaFila.Item(6), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id,  ficha, muestra, resultado, fecha,  operador, marca FROM inhibidores_control where ficha = " & texto & " and marca=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dInhibidoresControl
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.RESULTADO = CType(unaFila.Item(3), Integer)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.OPERADOR = CType(unaFila.Item(5), Integer)
                    c.MARCA = CType(unaFila.Item(6), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    

    Public Function marcar(ByVal o As Object) As Boolean
        Dim obj As dInhibidoresControl = CType(o, dInhibidoresControl)
        Dim sql As String = "UPDATE inhibidores_control SET  operador = " & obj.OPERADOR & ", marca = " & obj.MARCA & " WHERE id = " & obj.ID & " "

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
End Class
