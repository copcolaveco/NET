Public Class pCalidad
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidad = CType(o, dCalidad)
        Dim sql As String = "INSERT INTO calidad (" &
           "id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, " &
           "proteinav, caseina, densidad, ph, bhb, " &
           "sfa, ufa, mufa, pufa, c16, c180, c181, acetone, cisfat, transfat, " &
           "denovofa, mixedfa, preformedfa, denovofa2, mixedfa2, preformedfa2, nefa) VALUES (" &
           obj.ID & ", '" & obj.FICHA & "','" & obj.FECHA & "', '" & obj.EQUIPO & "', '" & obj.PRODUCTO & "', '" &
           obj.MUESTRA & "'," & obj.RC & ", " & obj.GRASA & ", " & obj.PROTEINA & ", " & obj.LACTOSA & ", " &
           obj.ST & ", " & obj.CRIOSCOPIA & ", " & obj.UREA & ", " & obj.PROTEINAV & ", " & obj.CASEINA & ", " &
           obj.DENSIDAD & ", " & obj.PH & ", " & obj.BHB & ", " &
           obj.SFA & ", " & obj.UFA & ", " & obj.MUFA & ", " & obj.PUFA & ", " &
           obj.C16_0 & ", " & obj.C18_0 & ", " & obj.C18_1C9 & ", " & obj.Acetone & ", " &
           obj.CisFat & ", " & obj.TransFat & ", " &
           obj.DenovoFA & ", " & obj.MixedFA & ", " & obj.PreformedFA & ", " &
           obj.DenovoRel & ", " & obj.MixedRel & ", " & obj.PreformedRel & ", " &
           obj.NEFA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidad = CType(o, dCalidad)
        Dim sql As String = "UPDATE calidad SET " &
              "ficha = '" & obj.FICHA & "', " &
              "fecha = '" & obj.FECHA & "', " &
              "equipo = '" & obj.EQUIPO & "', " &
              "producto = '" & obj.PRODUCTO & "', " &
              "muestra = '" & obj.MUESTRA & "', " &
              "rc = " & obj.RC & ", " &
              "grasa = " & obj.GRASA & ", " &
              "proteina = " & obj.PROTEINA & ", " &
              "lactosa = " & obj.LACTOSA & ", " &
              "st = " & obj.ST & ", " &
              "crioscopia = " & obj.CRIOSCOPIA & ", " &
              "urea = " & obj.UREA & ", " &
              "proteinav = " & obj.PROTEINAV & ", " &
              "caseina = " & obj.CASEINA & ", " &
              "densidad = " & obj.DENSIDAD & ", " &
              "ph = " & obj.PH & ", " &
              "bhb = " & obj.BHB & ", " &
              "sfa = " & obj.SFA & ", " &
              "ufa = " & obj.UFA & ", " &
              "mufa = " & obj.MUFA & ", " &
              "pufa = " & obj.PUFA & ", " &
              "c16 = " & obj.C16_0 & ", " &
              "c180 = " & obj.C18_0 & ", " &
              "c181 = " & obj.C18_1C9 & ", " &
              "acetone = " & obj.Acetone & ", " &
              "cisfat = " & obj.CisFat & ", " &
              "transfat = " & obj.TransFat & ", " &
              "denovofa = " & obj.DenovoFA & ", " &
              "mixedfa = " & obj.MixedFA & ", " &
              "preformedfa = " & obj.PreformedFA & ", " &
              "denovofa2 = " & obj.DenovoRel & ", " &
              "mixedfa2 = " & obj.MixedRel & ", " &
              "preformedfa2 = " & obj.PreformedRel & ", " &
              "nefa = " & obj.NEFA &
              " WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidad = CType(o, dCalidad)
        Dim sql As String = "DELETE FROM calidad WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidad', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminarxficha(ByVal o As Object) As Boolean
        Dim obj As dCalidad = CType(o, dCalidad)
        Dim sql As String = "DELETE FROM calidad WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCalidad
        Dim obj As dCalidad = CType(o, dCalidad)
        Dim c As New dCalidad
        Try
            Dim Ds As New DataSet

            Ds = Me.EjecutarSQL(
                "SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, " &
                "proteinav, caseina, densidad, ph, bhb, " &
                "sfa, ufa, mufa, pufa, c16, c180, c181, acetone, cisfat, transfat, " &
                "denovofa, mixedfa, preformedfa, denovofa2, mixedfa2, preformedfa2, nefa " &
                "FROM calidad WHERE ficha = '" & obj.FICHA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow = Ds.Tables(0).Rows(0)

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

                c.SFA = CType(unaFila.Item(18), Double)
                c.UFA = CType(unaFila.Item(19), Double)
                c.MUFA = CType(unaFila.Item(20), Double)
                c.PUFA = CType(unaFila.Item(21), Double)
                c.C16_0 = CType(unaFila.Item(22), Double)
                c.C18_0 = CType(unaFila.Item(23), Double)
                c.C18_1C9 = CType(unaFila.Item(24), Double)
                c.Acetone = CType(unaFila.Item(25), Double)
                c.CisFat = CType(unaFila.Item(26), Double)
                c.TransFat = CType(unaFila.Item(27), Double)

                c.DenovoFA = CType(unaFila.Item(28), Double)
                c.MixedFA = CType(unaFila.Item(29), Double)
                c.PreformedFA = CType(unaFila.Item(30), Double)

                c.DenovoRel = CType(unaFila.Item(31), Double)
                c.MixedRel = CType(unaFila.Item(32), Double)
                c.PreformedRel = CType(unaFila.Item(33), Double)

                c.NEFA = CType(unaFila.Item(34), Double)

                Return c
            End If

            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dCalidad
        Dim obj As dCalidad = CType(o, dCalidad)
        Dim c As New dCalidad
        Try
            Dim sql As String =
            "SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb, " &
            "sfa, ufa, mufa, pufa, c16, c180, c181, acetone, cisfat, transfat, " &
            "denovofa, mixedfa, preformedfa, denovofa2, mixedfa2, preformedfa2, nefa " &
            "FROM calidad WHERE ficha = '" & obj.FICHA & "' AND muestra = '" & obj.MUESTRA & "' " &
            "ORDER BY id ASC LIMIT 1"

            Dim Ds As DataSet = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow = Ds.Tables(0).Rows(0)

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

                c.SFA = CType(unaFila.Item(18), Double)
                c.UFA = CType(unaFila.Item(19), Double)
                c.MUFA = CType(unaFila.Item(20), Double)
                c.PUFA = CType(unaFila.Item(21), Double)

                c.C16_0 = CType(unaFila.Item(22), Double)
                c.C18_0 = CType(unaFila.Item(23), Double)
                c.C18_1C9 = CType(unaFila.Item(24), Double)

                c.Acetone = CType(unaFila.Item(25), Double)
                c.CisFat = CType(unaFila.Item(26), Double)
                c.TransFat = CType(unaFila.Item(27), Double)

                c.DenovoFA = CType(unaFila.Item(28), Double)
                c.MixedFA = CType(unaFila.Item(29), Double)
                c.PreformedFA = CType(unaFila.Item(30), Double)

                c.DenovoRel = CType(unaFila.Item(31), Double)
                c.MixedRel = CType(unaFila.Item(32), Double)
                c.PreformedRel = CType(unaFila.Item(33), Double)

                c.NEFA = CType(unaFila.Item(34), Double)

                Return c
            End If

            Return Nothing

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph FROM calidad order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidad
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
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfechaproceso(ByVal idficha As Long) As ArrayList
        Dim sql As String = "SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph FROM calidad WHERE ficha = " & idficha & " LIMIT  1"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidad
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
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph FROM calidad where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidad
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
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        'Dim sql As String = ("SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph FROM calidad where fecha BETWEEN '" & desde & "' AND'" & hasta & "'")
        Dim sql As String = ("SELECT MIN(id), ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph FROM calidad where fecha BETWEEN '" & desde & "' AND'" & hasta & "' GROUP BY ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph")

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidad
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
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfechaxempresa(ByVal desde As String, ByVal hasta As String, ByVal idempresa As Long) As ArrayList
        'Dim sql As String = ("SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph FROM calidad where fecha BETWEEN '" & desde & "' AND'" & hasta & "'")
        Dim sql As String = ("SELECT MIN(id), ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph FROM calidad where fecha BETWEEN '" & desde & "' AND'" & hasta & "' GROUP BY ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph")

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidad
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
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT MIN(id), ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph FROM calidad where ficha = " & texto & " Order by muestra asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidad
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
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxficha(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT MIN(id), ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb, sfa, ufa, mufa, pufa, c16, c180, c181, acetone, cisfat, transfat, " &
            "denovofa, mixedfa, preformedfa, denovofa2, mixedfa2, preformedfa2, nefa  FROM control where ficha = " & texto & " group by ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, bhb Order by muestra asc")

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

                    c.SFA = CType(unaFila.Item(18), Double)
                    c.UFA = CType(unaFila.Item(19), Double)
                    c.MUFA = CType(unaFila.Item(20), Double)
                    c.PUFA = CType(unaFila.Item(21), Double)

                    c.C16_0 = CType(unaFila.Item(22), Double)
                    c.C18_0 = CType(unaFila.Item(23), Double)
                    c.C18_1C9 = CType(unaFila.Item(24), Double)

                    c.Acetone = CType(unaFila.Item(25), Double)
                    c.CisFat = CType(unaFila.Item(26), Double)
                    c.TransFat = CType(unaFila.Item(27), Double)

                    c.DenovoFA = CType(unaFila.Item(28), Double)
                    c.MixedFA = CType(unaFila.Item(29), Double)
                    c.PreformedFA = CType(unaFila.Item(30), Double)

                    c.DenovoRel = CType(unaFila.Item(31), Double)
                    c.MixedRel = CType(unaFila.Item(32), Double)
                    c.PreformedRel = CType(unaFila.Item(33), Double)

                    c.NEFA = CType(unaFila.Item(34), Double)

                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    'Funcion para buscar en tabla auxiliar que no exista el registro
    Public Function buscaraux(ByVal ficha As String, ByVal muestra As String) As dCalidad
        'Dim obj As dCalidad = CType(o, dCalidad)
        Dim c As New dCalidad
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph FROM calidadaux WHERE ficha = '" & ficha & "' AND muestra = '" & muestra & "'")

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
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    'Funcion para guardar en tabla auxiliar
    Public Function guardaraux(ByVal o As Object) As Boolean
        Dim obj As dCalidad = CType(o, dCalidad)
        Dim sql As String = "INSERT INTO calidadaux (id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph) VALUES (" & obj.ID & ", '" & obj.FICHA & "','" & obj.FECHA & "', '" & obj.EQUIPO & "', '" & obj.PRODUCTO & "', '" & obj.MUESTRA & "'," & obj.RC & ", " & obj.GRASA & ", " & obj.PROTEINA & ", " & obj.LACTOSA & ", " & obj.ST & ", " & obj.CRIOSCOPIA & ", " & obj.UREA & "," & obj.PROTEINAV & "," & obj.CASEINA & "," & obj.DENSIDAD & "," & obj.PH & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        

        Return EjecutarTransaccion(lista)
    End Function
    'Funcion para guardar en tabla auxiliar 2
    Public Function guardaraux2(ByVal o As Object) As Boolean
        Dim obj As dCalidad = CType(o, dCalidad)
        Dim sql As String = "INSERT INTO calidadaux2 (id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph) VALUES (" & obj.ID & ", '" & obj.FICHA & "','" & obj.FECHA & "', '" & obj.EQUIPO & "', '" & obj.PRODUCTO & "', '" & obj.MUESTRA & "'," & obj.RC & ", " & obj.GRASA & ", " & obj.PROTEINA & ", " & obj.LACTOSA & ", " & obj.ST & ", " & obj.CRIOSCOPIA & ", " & obj.UREA & "," & obj.PROTEINAV & "," & obj.CASEINA & "," & obj.DENSIDAD & "," & obj.PH & ")"

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function

    Public Function ListarPerfilAG(ByVal ficha As Long) As ArrayList
        Try
            Dim sql As String =
                "SELECT " &
                "   MIN(c.id), " &
                "   c.muestra, " &
                "   c.grasa, " &
                "   c.sfa, " &
                "   c.ufa, " &
                "   c.mufa, " &
                "   c.pufa, " &
                "   c.c181, " &
                "   c.denovofa " &
                "FROM calidad c " &
                "INNER JOIN nuevoanalisis na ON na.ficha = c.ficha " &
                "WHERE c.ficha = " & ficha & " AND na.analisis = 700 " &
                "GROUP BY c.muestra, c.grasa, c.sfa, c.ufa, c.mufa, c.pufa, c.c181, c.denovofa " &
                "ORDER BY c.muestra ASC"

            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            End If

            Dim lista As New ArrayList

            For Each fila As DataRow In Ds.Tables(0).Rows
                Dim c As New dCalidad

                c.ID = CType(fila.Item(0), Long)
                c.MUESTRA = CType(fila.Item(1), String)
                c.GRASA = CType(fila.Item(2), Double)
                c.SFA = CType(fila.Item(3), Double)
                c.UFA = CType(fila.Item(4), Double)
                c.MUFA = CType(fila.Item(5), Double)
                c.PUFA = CType(fila.Item(6), Double)
                c.C18_1C9 = CType(fila.Item(7), Double)
                c.DenovoFA = CType(fila.Item(8), Double)

                lista.Add(c)
            Next

            Return lista

        Catch ex As Exception
            Return Nothing
        End Try
    End Function



End Class
