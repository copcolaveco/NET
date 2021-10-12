Public Class pMicotoxinasLeche
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMicotoxinasLeche = CType(o, dMicotoxinasLeche)
        Dim sql As String = "INSERT INTO micotoxinas_leche (id, ficha, fecha,  muestra, resultado, operador, marca) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.FECHA & "', '" & obj.MUESTRA & "','" & obj.RESULTADO & "'," & obj.OPERADOR & "," & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'micotoxinas_leche', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMicotoxinasLeche = CType(o, dMicotoxinasLeche)
        Dim sql As String = "UPDATE micotoxinas_leche SET ficha=" & obj.FICHA & ", fecha='" & obj.FECHA & "', muestra='" & obj.MUESTRA & "', resultado='" & obj.RESULTADO & "', operador=" & obj.OPERADOR & ", marca=" & obj.MARCA & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'micotoxinas_leche', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMicotoxinasLeche = CType(o, dMicotoxinasLeche)
        Dim sql As String = "UPDATE micotoxinas_leche SET marca=" & obj.MARCA & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'micotoxinas_leche', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMicotoxinasLeche = CType(o, dMicotoxinasLeche)
        Dim sql As String = "DELETE FROM micotoxinas_leche WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'micotoxinas_leche', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMicotoxinasLeche = CType(o, dMicotoxinasLeche)
        Dim sql As String = "DELETE FROM micotoxinas_leche WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'micotoxinas_leche', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dMicotoxinasLeche
        Dim obj As dMicotoxinasLeche = CType(o, dMicotoxinasLeche)
        Dim m As New dMicotoxinasLeche
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha,  muestra, resultado, operador, marca FROM micotoxinas_leche WHERE ficha = " & obj.FICHA & "")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                m.ID = CType(unaFila.Item(0), Long)
                m.FICHA = CType(unaFila.Item(1), Long)
                m.FECHA = CType(unaFila.Item(2), String)
                m.MUESTRA = CType(unaFila.Item(3), String)
                m.RESULTADO = CType(unaFila.Item(4), String)
                m.OPERADOR = CType(unaFila.Item(5), Integer)
                m.MARCA = CType(unaFila.Item(6), Integer)
                Return m
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxficha(ByVal o As Object) As dMicotoxinasLeche
        Dim obj As dMicotoxinasLeche = CType(o, dMicotoxinasLeche)
        Dim m As New dMicotoxinasLeche
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha,  muestra, resultado, operador, marca FROM micotoxinas_leche WHERE ficha = " & obj.FICHA & "")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                m.ID = CType(unaFila.Item(0), Long)
                m.FICHA = CType(unaFila.Item(1), Long)
                m.FECHA = CType(unaFila.Item(2), String)
                m.MUESTRA = CType(unaFila.Item(3), String)
                m.RESULTADO = CType(unaFila.Item(4), String)
                m.OPERADOR = CType(unaFila.Item(5), Integer)
                m.MARCA = CType(unaFila.Item(6), Integer)
                Return m
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dMicotoxinasLeche
        Dim obj As dMicotoxinasLeche = CType(o, dMicotoxinasLeche)
        Dim m As New dMicotoxinasLeche
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha,  muestra, resultado, operador, marca FROM micotoxinas_leche WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "'")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                m.ID = CType(unaFila.Item(0), Long)
                m.FICHA = CType(unaFila.Item(1), Long)
                m.FECHA = CType(unaFila.Item(2), String)
                m.MUESTRA = CType(unaFila.Item(3), String)
                m.RESULTADO = CType(unaFila.Item(4), String)
                m.OPERADOR = CType(unaFila.Item(5), Integer)
                m.MARCA = CType(unaFila.Item(6), Integer)
                Return m
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList

        Dim sql As String = "SELECT id, ficha, fecha,  muestra, resultado, operador, marca FROM micotoxinas_leche WHERE marca = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dMicotoxinasLeche
                   m.ID = CType(unaFila.Item(0), Long)
                    m.FICHA = CType(unaFila.Item(1), Long)
                    m.FECHA = CType(unaFila.Item(2), String)
                    m.MUESTRA = CType(unaFila.Item(3), String)
                    m.RESULTADO = CType(unaFila.Item(4), String)
                    m.OPERADOR = CType(unaFila.Item(5), Integer)
                    m.MARCA = CType(unaFila.Item(6), Integer)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM micotoxinas_leche WHERE marca = 0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dMicotoxinasLeche
                    m.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = "SELECT id, ficha, fecha,  muestra, resultado, operador, marca FROM micotoxinas_leche where ficha = " & texto & " AND marca = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(Sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dMicotoxinasLeche
                   m.ID = CType(unaFila.Item(0), Long)
                    m.FICHA = CType(unaFila.Item(1), Long)
                    m.FECHA = CType(unaFila.Item(2), String)
                    m.MUESTRA = CType(unaFila.Item(3), String)
                    m.RESULTADO = CType(unaFila.Item(4), String)
                    m.OPERADOR = CType(unaFila.Item(5), Integer)
                    m.MARCA = CType(unaFila.Item(6), Integer)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fecha,  muestra, resultado, operador, marca FROM micotoxinas_leche where marca = 0 and ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dMicotoxinasLeche
                    m.ID = CType(unaFila.Item(0), Long)
                    m.FICHA = CType(unaFila.Item(1), Long)
                    m.FECHA = CType(unaFila.Item(2), String)
                    m.MUESTRA = CType(unaFila.Item(3), String)
                    m.RESULTADO = CType(unaFila.Item(4), String)
                    m.OPERADOR = CType(unaFila.Item(5), Integer)
                    m.MARCA = CType(unaFila.Item(6), Integer)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fecha,  muestra, resultado, operador, marca FROM micotoxinas_leche where marca = 1 and ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(Sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dMicotoxinasLeche
                    m.ID = CType(unaFila.Item(0), Long)
                    m.FICHA = CType(unaFila.Item(1), Long)
                    m.FECHA = CType(unaFila.Item(2), String)
                    m.MUESTRA = CType(unaFila.Item(3), String)
                    m.RESULTADO = CType(unaFila.Item(4), String)
                    m.OPERADOR = CType(unaFila.Item(5), Integer)
                    m.MARCA = CType(unaFila.Item(6), Integer)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fecha,  muestra, resultado, operador, marca FROM micotoxinas_leche where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dMicotoxinasLeche
                    m.ID = CType(unaFila.Item(0), Long)
                    m.FICHA = CType(unaFila.Item(1), Long)
                    m.FECHA = CType(unaFila.Item(2), String)
                    m.MUESTRA = CType(unaFila.Item(3), String)
                    m.RESULTADO = CType(unaFila.Item(4), String)
                    m.OPERADOR = CType(unaFila.Item(5), Integer)
                    m.MARCA = CType(unaFila.Item(6), Integer)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
