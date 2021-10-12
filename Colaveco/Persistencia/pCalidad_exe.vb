Public Class pCalidad_exe
    Inherits Conectoras.ConexionMySQL_exe
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidad_exe = CType(o, dCalidad_exe)
        Dim sql As String = "INSERT INTO empresa_modificado (id, fecha,  rc, grasa, proteina, lactosa, rb, st) VALUES (" & obj.ID & ", '" & obj.FECHA & "', " & obj.RC & ", " & obj.GRASA & ", " & obj.PROTEINA & ", " & obj.LACTOSA & ", " & obj.RB & ", " & obj.ST & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidad_exe', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidad_exe = CType(o, dCalidad_exe)
        Dim sql As String = "UPDATE empresa_modificado SET fecha ='" & obj.FECHA & "', rc=" & obj.RC & ",grasa=" & obj.GRASA & ", proteina=" & obj.PROTEINA & ", lactosa=" & obj.LACTOSA & ", rb=" & obj.RB & ",st=" & obj.ST & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidad_exe', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidad_exe = CType(o, dCalidad_exe)
        Dim sql As String = "DELETE FROM empresa_modificado WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidad_exe', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCalidad_exe
        Dim obj As dCalidad_exe = CType(o, dCalidad_exe)
        Dim c As New dCalidad_exe
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, rc, grasa, proteina, lactosa, rb, st FROM empresa_modificado WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.RC = CType(unaFila.Item(2), Integer)
                c.GRASA = CType(unaFila.Item(3), Double)
                c.PROTEINA = CType(unaFila.Item(4), Double)
                c.LACTOSA = CType(unaFila.Item(5), Double)
                c.RB = CType(unaFila.Item(6), Integer)
                c.ST = CType(unaFila.Item(7), Double)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, ifnull(rc,0), ifnull(grasa,0), ifnull(proteina,0), ifnull(lactosa,0), ifnull(rb,0), ifnull(st,0) FROM empresa_modificado order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidad_exe
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.RC = CType(unaFila.Item(2), Integer)
                    c.GRASA = CType(unaFila.Item(3), Double)
                    c.PROTEINA = CType(unaFila.Item(4), Double)
                    c.LACTOSA = CType(unaFila.Item(5), Double)
                    c.RB = CType(unaFila.Item(6), Integer)
                    c.ST = CType(unaFila.Item(7), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fecha, ifnull(rc,0), ifnull(grasa,0), ifnull(proteina,0), ifnull(lactosa,0), ifnull(rb,0), ifnull(st,0) FROM empresa_modificado where ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidad_exe
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.RC = CType(unaFila.Item(2), Integer)
                    c.GRASA = CType(unaFila.Item(3), Double)
                    c.PROTEINA = CType(unaFila.Item(4), Double)
                    c.LACTOSA = CType(unaFila.Item(5), Double)
                    c.RB = CType(unaFila.Item(6), Integer)
                    c.ST = CType(unaFila.Item(7), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, fecha, ifnull(rc,0), ifnull(grasa,0), ifnull(proteina,0), ifnull(lactosa,0), ifnull(rb,0), ifnull(st,0) FROM empresa_modificado where fecha BETWEEN '" & desde & "' and '" & hasta & "' Order by fecha asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidad_exe
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.RC = CType(unaFila.Item(2), Integer)
                    c.GRASA = CType(unaFila.Item(3), Double)
                    c.PROTEINA = CType(unaFila.Item(4), Double)
                    c.LACTOSA = CType(unaFila.Item(5), Double)
                    c.RB = CType(unaFila.Item(6), Integer)
                    c.ST = CType(unaFila.Item(7), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
  
End Class
