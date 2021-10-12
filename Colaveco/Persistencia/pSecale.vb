Public Class pSecale
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSecale = CType(o, dSecale)
        Dim sql As String = "INSERT INTO secale (id, fecha, empresa, muestra, grasa, proteina, lactosa, st, rc,  rb, rbpetri) VALUES (" & obj.ID & ", '" & obj.FECHA & "', '" & obj.EMPRESA & "',  '" & obj.MUESTRA & "'," & obj.GRASA & ", " & obj.PROTEINA & ", " & obj.LACTOSA & ", " & obj.ST & "," & obj.RC & ",  " & obj.RB & ",  " & obj.RBPETRI & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'secale', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSecale = CType(o, dSecale)
        Dim sql As String = "UPDATE secale SET fecha ='" & obj.FECHA & "', empresa='" & obj.EMPRESA & "',muestra='" & obj.MUESTRA & "',grasa=" & obj.GRASA & ", proteina=" & obj.PROTEINA & ", lactosa=" & obj.LACTOSA & ", st=" & obj.ST & ",rc=" & obj.RC & ", rb=" & obj.RB & ", rbpetri =" & obj.RBPETRI & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'secale', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSecale = CType(o, dSecale)
        Dim sql As String = "DELETE FROM secale WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'secale', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dSecale
        Dim obj As dSecale = CType(o, dSecale)
        Dim s As New dSecale
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, empresa, muestra, grasa, proteina, lactosa, st, rc,  rb, rbpetri FROM secale WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Long)
                s.FECHA = CType(unaFila.Item(1), String)
                s.EMPRESA = CType(unaFila.Item(2), String)
                s.MUESTRA = CType(unaFila.Item(3), String)
                s.GRASA = CType(unaFila.Item(4), Double)
                s.PROTEINA = CType(unaFila.Item(5), Double)
                s.LACTOSA = CType(unaFila.Item(6), Double)
                s.ST = CType(unaFila.Item(7), Double)
                s.RC = CType(unaFila.Item(8), Long)
                s.RB = CType(unaFila.Item(9), Long)
                s.RBPETRI = CType(unaFila.Item(10), Long)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, empresa, muestra, grasa, proteina, lactosa, st, rc,  rb, rbpetri FROM secale order by fecha desc, id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSecale
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.EMPRESA = CType(unaFila.Item(2), String)
                    s.MUESTRA = CType(unaFila.Item(3), String)
                    s.GRASA = CType(unaFila.Item(4), Double)
                    s.PROTEINA = CType(unaFila.Item(5), Double)
                    s.LACTOSA = CType(unaFila.Item(6), Double)
                    s.ST = CType(unaFila.Item(7), Double)
                    s.RC = CType(unaFila.Item(8), Long)
                    s.RB = CType(unaFila.Item(9), Long)
                    s.RBPETRI = CType(unaFila.Item(10), Long)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fecha, empresa, muestra, grasa, proteina, lactosa, st, rc,  rb, rbpetri FROM secale where id = " & texto & "")

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSecale
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.EMPRESA = CType(unaFila.Item(2), String)
                    s.MUESTRA = CType(unaFila.Item(3), String)
                    s.GRASA = CType(unaFila.Item(4), Double)
                    s.PROTEINA = CType(unaFila.Item(5), Double)
                    s.LACTOSA = CType(unaFila.Item(6), Double)
                    s.ST = CType(unaFila.Item(7), Double)
                    s.RC = CType(unaFila.Item(8), Long)
                    s.RB = CType(unaFila.Item(9), Long)
                    s.RBPETRI = CType(unaFila.Item(10), Long)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList

        Dim sql As String = ("SELECT id, fecha, empresa, muestra, grasa, proteina, lactosa, st, rc,  rb, rbpetri FROM secale where fecha BETWEEN  '" & desde & "' AND '" & hasta & "' ")

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSecale
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.EMPRESA = CType(unaFila.Item(2), String)
                    s.MUESTRA = CType(unaFila.Item(3), String)
                    s.GRASA = CType(unaFila.Item(4), Double)
                    s.PROTEINA = CType(unaFila.Item(5), Double)
                    s.LACTOSA = CType(unaFila.Item(6), Double)
                    s.ST = CType(unaFila.Item(7), Double)
                    s.RC = CType(unaFila.Item(8), Long)
                    s.RB = CType(unaFila.Item(9), Long)
                    s.RBPETRI = CType(unaFila.Item(10), Long)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcolaveco(ByVal desde As String, ByVal hasta As String) As ArrayList

        Dim sql As String = ("SELECT id, fecha, empresa, muestra, grasa, proteina, lactosa, st, rc,  rb, rbpetri FROM secale where fecha BETWEEN  '" & desde & "' AND '" & hasta & "' AND empresa = 'colaveco' ")

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSecale
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.EMPRESA = CType(unaFila.Item(2), String)
                    s.MUESTRA = CType(unaFila.Item(3), String)
                    s.GRASA = CType(unaFila.Item(4), Double)
                    s.PROTEINA = CType(unaFila.Item(5), Double)
                    s.LACTOSA = CType(unaFila.Item(6), Double)
                    s.ST = CType(unaFila.Item(7), Double)
                    s.RC = CType(unaFila.Item(8), Long)
                    s.RB = CType(unaFila.Item(9), Long)
                    s.RBPETRI = CType(unaFila.Item(10), Long)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsecale(ByVal desde As String, ByVal hasta As String) As ArrayList

        Dim sql As String = ("SELECT id, fecha, empresa, muestra, grasa, proteina, lactosa, st, rc,  rb, rbpetri FROM secale where fecha BETWEEN  '" & desde & "' AND '" & hasta & "' AND empresa = 'secale' ")

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSecale
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.EMPRESA = CType(unaFila.Item(2), String)
                    s.MUESTRA = CType(unaFila.Item(3), String)
                    s.GRASA = CType(unaFila.Item(4), Double)
                    s.PROTEINA = CType(unaFila.Item(5), Double)
                    s.LACTOSA = CType(unaFila.Item(6), Double)
                    s.ST = CType(unaFila.Item(7), Double)
                    s.RC = CType(unaFila.Item(8), Long)
                    s.RB = CType(unaFila.Item(9), Long)
                    s.RBPETRI = CType(unaFila.Item(10), Long)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
