Public Class pControl
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControl = CType(o, dControl)
        Dim sql As String = "INSERT INTO control (id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb) VALUES (" & obj.ID & ", '" & obj.FICHA & "','" & obj.FECHA & "', '" & obj.EQUIPO & "', '" & obj.PRODUCTO & "', '" & obj.MUESTRA & "'," & obj.RC & ", " & obj.GRASA & ", " & obj.PROTEINA & ", " & obj.LACTOSA & ", " & obj.ST & ", " & obj.CRIOSCOPIA & ", " & obj.UREA & "," & obj.PROTEINAV & "," & obj.CASEINA & "," & obj.DENSIDAD & "," & obj.PH & "," & obj.BHB & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'control', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControl = CType(o, dControl)
        Dim sql As String = "UPDATE control SET ficha = '" & obj.FICHA & "',  fecha ='" & obj.FECHA & "', equipo='" & obj.EQUIPO & "',producto='" & obj.PRODUCTO & "',muestra='" & obj.MUESTRA & "',rc=" & obj.RC & ",grasa=" & obj.GRASA & ", proteina=" & obj.PROTEINA & ", lactosa=" & obj.LACTOSA & ", st=" & obj.ST & ", crioscopia=" & obj.CRIOSCOPIA & ",urea=" & obj.UREA & ",proteinav=" & obj.PROTEINAV & ", caseina=" & obj.CASEINA & ",densidad=" & obj.DENSIDAD & ",ph=" & obj.PH & ",bhb=" & obj.BHB & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'control', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal ficha As String, ByVal id As String, ByVal muestra As String) As Boolean
        'Dim obj As dControl = CType(o, dControl)
        Dim sql As String = "UPDATE control SET muestra='" & muestra & "', caravana_mod= 1 WHERE ficha = '" & ficha & "' and muestra= '" & id & "' and caravana_mod = 0"

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControl = CType(o, dControl)
        Dim sql As String = "DELETE FROM control WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'control', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminarxficha(ByVal o As Object) As Boolean
        Dim obj As dControl = CType(o, dControl)
        Dim sql As String = "DELETE FROM control WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dControl
        Dim obj As dControl = CType(o, dControl)
        Dim c As New dControl
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb FROM control WHERE ficha = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FICHA = CType(unaFila.Item(1), String)
                c.FECHA = CType(unaFila.Item(2), String)
                c.EQUIPO = CType(unaFila.Item(3), String)
                c.PRODUCTO = CType(unaFila.Item(4), String)
                c.MUESTRA = CType(unaFila.Item(5), String)
                c.RC = CType(unaFila.Item(6), Integer)
                c.GRASA = CType(unaFila.Item(7), Double)
                c.PROTEINA = CType(unaFila.Item(8), Double)
                c.LACTOSA = CType(unaFila.Item(9), Double)
                c.ST = CType(unaFila.Item(10), Double)
                c.CRIOSCOPIA = CType(unaFila.Item(11), Integer)
                c.UREA = CType(unaFila.Item(12), Integer)
                c.PROTEINAV = CType(unaFila.Item(13), Double)
                c.CASEINA = CType(unaFila.Item(14), Double)
                c.DENSIDAD = CType(unaFila.Item(15), Double)
                c.PH = CType(unaFila.Item(16), Double)
                c.BHB = CType(unaFila.Item(17), Double)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb FROM control order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControl
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.EQUIPO = CType(unaFila.Item(3), String)
                    c.PRODUCTO = CType(unaFila.Item(4), String)
                    c.MUESTRA = CType(unaFila.Item(5), String)
                    c.RC = CType(unaFila.Item(6), Integer)
                    c.GRASA = CType(unaFila.Item(7), Double)
                    c.PROTEINA = CType(unaFila.Item(8), Double)
                    c.LACTOSA = CType(unaFila.Item(9), Double)
                    c.ST = CType(unaFila.Item(10), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(11), Integer)
                    c.UREA = CType(unaFila.Item(12), Integer)
                    c.PROTEINAV = CType(unaFila.Item(13), Double)
                    c.CASEINA = CType(unaFila.Item(14), Double)
                    c.DENSIDAD = CType(unaFila.Item(15), Double)
                    c.PH = CType(unaFila.Item(16), Double)
                    c.BHB = CType(unaFila.Item(17), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfechaproceso(ByVal idficha As Long) As ArrayList
        Dim sql As String = "SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb FROM control WHERE ficha = " & idficha & " LIMIT 1"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControl
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.EQUIPO = CType(unaFila.Item(3), String)
                    c.PRODUCTO = CType(unaFila.Item(4), String)
                    c.MUESTRA = CType(unaFila.Item(5), String)
                    c.RC = CType(unaFila.Item(6), Integer)
                    c.GRASA = CType(unaFila.Item(7), Double)
                    c.PROTEINA = CType(unaFila.Item(8), Double)
                    c.LACTOSA = CType(unaFila.Item(9), Double)
                    c.ST = CType(unaFila.Item(10), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(11), Integer)
                    c.UREA = CType(unaFila.Item(12), Integer)
                    c.PROTEINAV = CType(unaFila.Item(13), Double)
                    c.CASEINA = CType(unaFila.Item(14), Double)
                    c.DENSIDAD = CType(unaFila.Item(15), Double)
                    c.PH = CType(unaFila.Item(16), Double)
                    c.BHB = CType(unaFila.Item(17), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        'Dim sql As String = ("SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph FROM control where ficha = " & texto)
        Dim sql As String = ("SELECT MIN(id), ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb FROM control where ficha = " & texto & " group by ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControl
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.EQUIPO = CType(unaFila.Item(3), String)
                    c.PRODUCTO = CType(unaFila.Item(4), String)
                    c.MUESTRA = CType(unaFila.Item(5), String)
                    c.RC = CType(unaFila.Item(6), Integer)
                    c.GRASA = CType(unaFila.Item(7), Double)
                    c.PROTEINA = CType(unaFila.Item(8), Double)
                    c.LACTOSA = CType(unaFila.Item(9), Double)
                    c.ST = CType(unaFila.Item(10), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(11), Integer)
                    c.UREA = CType(unaFila.Item(12), Integer)
                    c.PROTEINAV = CType(unaFila.Item(13), Double)
                    c.CASEINA = CType(unaFila.Item(14), Double)
                    c.DENSIDAD = CType(unaFila.Item(15), Double)
                    c.PH = CType(unaFila.Item(16), Double)
                    c.BHB = CType(unaFila.Item(17), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList

        Dim sql As String = ("SELECT MIN(id), ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb FROM control where ficha = " & texto & " group by ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb Order by muestra asc")

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControl
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.EQUIPO = CType(unaFila.Item(3), String)
                    c.PRODUCTO = CType(unaFila.Item(4), String)
                    c.MUESTRA = CType(unaFila.Item(5), String)
                    c.RC = CType(unaFila.Item(6), Integer)
                    c.GRASA = CType(unaFila.Item(7), Double)
                    c.PROTEINA = CType(unaFila.Item(8), Double)
                    c.LACTOSA = CType(unaFila.Item(9), Double)
                    c.ST = CType(unaFila.Item(10), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(11), Integer)
                    c.UREA = CType(unaFila.Item(12), Integer)
                    c.PROTEINAV = CType(unaFila.Item(13), Double)
                    c.CASEINA = CType(unaFila.Item(14), Double)
                    c.DENSIDAD = CType(unaFila.Item(15), Double)
                    c.PH = CType(unaFila.Item(16), Double)
                    c.BHB = CType(unaFila.Item(17), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxficha(ByVal texto As Long) As ArrayList

        Dim sql As String = ("SELECT MIN(id), ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb FROM control where ficha = " & texto & " group by ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb Order by muestra asc")

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControl
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.EQUIPO = CType(unaFila.Item(3), String)
                    c.PRODUCTO = CType(unaFila.Item(4), String)
                    c.MUESTRA = CType(unaFila.Item(5), String)
                    c.RC = CType(unaFila.Item(6), Integer)
                    c.GRASA = CType(unaFila.Item(7), Double)
                    c.PROTEINA = CType(unaFila.Item(8), Double)
                    c.LACTOSA = CType(unaFila.Item(9), Double)
                    c.ST = CType(unaFila.Item(10), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(11), Integer)
                    c.UREA = CType(unaFila.Item(12), Integer)
                    c.PROTEINAV = CType(unaFila.Item(13), Double)
                    c.CASEINA = CType(unaFila.Item(14), Double)
                    c.DENSIDAD = CType(unaFila.Item(15), Double)
                    c.PH = CType(unaFila.Item(16), Double)
                    c.BHB = CType(unaFila.Item(17), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList

        Dim sql As String = ("SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb FROM control where fecha BETWEEN  '" & desde & "' AND '" & hasta & "' ")

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControl
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.EQUIPO = CType(unaFila.Item(3), String)
                    c.PRODUCTO = CType(unaFila.Item(4), String)
                    c.MUESTRA = CType(unaFila.Item(5), String)
                    c.RC = CType(unaFila.Item(6), Integer)
                    c.GRASA = CType(unaFila.Item(7), Double)
                    c.PROTEINA = CType(unaFila.Item(8), Double)
                    c.LACTOSA = CType(unaFila.Item(9), Double)
                    c.ST = CType(unaFila.Item(10), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(11), Integer)
                    c.UREA = CType(unaFila.Item(12), Integer)
                    c.PROTEINAV = CType(unaFila.Item(13), Double)
                    c.CASEINA = CType(unaFila.Item(14), Double)
                    c.DENSIDAD = CType(unaFila.Item(15), Double)
                    c.PH = CType(unaFila.Item(16), Double)
                    c.BHB = CType(unaFila.Item(17), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList

        Dim sql As String = ("SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb FROM control where fecha BETWEEN  '" & desde & "' AND '" & hasta & "' ")

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControl
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.EQUIPO = CType(unaFila.Item(3), String)
                    c.PRODUCTO = CType(unaFila.Item(4), String)
                    c.MUESTRA = CType(unaFila.Item(5), String)
                    c.RC = CType(unaFila.Item(6), Integer)
                    c.GRASA = CType(unaFila.Item(7), Double)
                    c.PROTEINA = CType(unaFila.Item(8), Double)
                    c.LACTOSA = CType(unaFila.Item(9), Double)
                    c.ST = CType(unaFila.Item(10), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(11), Integer)
                    c.UREA = CType(unaFila.Item(12), Integer)
                    c.PROTEINAV = CType(unaFila.Item(13), Double)
                    c.CASEINA = CType(unaFila.Item(14), Double)
                    c.DENSIDAD = CType(unaFila.Item(15), Double)
                    c.PH = CType(unaFila.Item(16), Double)
                    c.BHB = CType(unaFila.Item(17), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporrc(ByVal texto As Long) As ArrayList
       
        Dim sql As String = ("SELECT MIN(id), ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb FROM control where ficha = " & texto & " group by ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb Order by rc desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControl
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.EQUIPO = CType(unaFila.Item(3), String)
                    c.PRODUCTO = CType(unaFila.Item(4), String)
                    c.MUESTRA = CType(unaFila.Item(5), String)
                    c.RC = CType(unaFila.Item(6), Integer)
                    c.GRASA = CType(unaFila.Item(7), Double)
                    c.PROTEINA = CType(unaFila.Item(8), Double)
                    c.LACTOSA = CType(unaFila.Item(9), Double)
                    c.ST = CType(unaFila.Item(10), Double)
                    c.CRIOSCOPIA = CType(unaFila.Item(11), Integer)
                    c.UREA = CType(unaFila.Item(12), Integer)
                    c.PROTEINAV = CType(unaFila.Item(13), Double)
                    c.CASEINA = CType(unaFila.Item(14), Double)
                    c.DENSIDAD = CType(unaFila.Item(15), Double)
                    c.PH = CType(unaFila.Item(16), Double)
                    c.BHB = CType(unaFila.Item(17), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
