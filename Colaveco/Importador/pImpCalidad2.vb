Public Class pImpCalidad2
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dImpCalidad2 = CType(o, dImpCalidad2)
        Dim sql As String = "INSERT INTO calidad (id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, grasa_b, grasa_a, cit, agl, sng, sfa, ufa, mufa, pufa, c16, c180, c181, bhb, acetone, cisfat, transfat, denovofa, mixedfa, preformedfa, denovofa2, mixedfa2, preformedfa2, nefa) VALUES (" & obj.ID & ", '" & obj.FICHA & "','" & obj.FECHA & "', '" & obj.EQUIPO & "', '" & obj.PRODUCTO & "', '" & obj.MUESTRA & "'," & obj.RC & ", " & obj.GRASA & ", " & obj.PROTEINA & ", " & obj.LACTOSA & ", " & obj.ST & ", " & obj.CRIOSCOPIA & ", " & obj.UREA & "," & obj.PROTEINAV & "," & obj.CASEINA & "," & obj.DENSIDAD & "," & obj.PH & "," & obj.GRASA_B & "," & obj.GRASA_A & "," & obj.CIT & "," & obj.AGL & "," & obj.SNG & "," & obj.SFA & "," & obj.UFA & "," & obj.MUFA & "," & obj.PUFA & "," & obj.C16 & "," & obj.C180 & "," & obj.C181 & "," & obj.BHB & "," & obj.ACETONE & "," & obj.CISFAT & "," & obj.TRANSFAT & "," & obj.DENOVOFA & "," & obj.MIXEDFA & "," & obj.PREFORMEDFA & "," & obj.DENOVOFA2 & "," & obj.MIXEDFA2 & "," & obj.PREFORMEDFA2 & "," & obj.NEFA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dImpCalidad2 = CType(o, dImpCalidad2)
        Dim sql As String = "UPDATE calidad SET ficha = '" & obj.FICHA & "',  fecha ='" & obj.FECHA & "', equipo='" & obj.EQUIPO & "',producto='" & obj.PRODUCTO & "',muestra='" & obj.MUESTRA & "',rc=" & obj.RC & ",grasa=" & obj.GRASA & ", proteina=" & obj.PROTEINA & ", lactosa=" & obj.LACTOSA & ", st=" & obj.ST & ", crioscopia=" & obj.CRIOSCOPIA & ",urea=" & obj.UREA & ",proteinav=" & obj.PROTEINAV & ", caseina=" & obj.CASEINA & ",densidad=" & obj.DENSIDAD & ",ph=" & obj.PH & ",grasa_b=" & obj.GRASA_B & ",grasa_a=" & obj.GRASA_A & ",cit=" & obj.CIT & ",agl=" & obj.AGL & ",sng=" & obj.SNG & ",sfa=" & obj.SFA & ",ufa=" & obj.UFA & ",mufa=" & obj.MUFA & ",pufa=" & obj.PUFA & ",c16=" & obj.C16 & ",c180=" & obj.C180 & ",c181=" & obj.C181 & ",bhb=" & obj.BHB & ",acetone=" & obj.ACETONE & ",cisfat=" & obj.CISFAT & ",transfat=" & obj.TRANSFAT & ",denovofa=" & obj.DENOVOFA & ",mixedfa=" & obj.MIXEDFA & ",preformedfa=" & obj.PREFORMEDFA & ",denovofa2=" & obj.DENOVOFA2 & ",mixedfa2=" & obj.MIXEDFA2 & ",preformedfa2=" & obj.PREFORMEDFA2 & ",nefa=" & obj.NEFA & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dImpCalidad2 = CType(o, dImpCalidad2)
        Dim sql As String = "DELETE FROM calidad WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dImpCalidad2
        Dim obj As dImpCalidad2 = CType(o, dImpCalidad2)
        Dim c As New dImpCalidad2
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, grasa_b, grasa_a, cit, agl, sng, sfa, ufa, mufa, pufa, c16, c180, c181, bhb, acetone, cisfat, transfat, denovofa, mixedfa, preformedfa, denovofa2, mixedfa2, preformedfa2, nefa FROM calidad WHERE ficha = " & obj.ID)

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
                c.GRASA_B = CType(unaFila.Item(17), Double)
                c.GRASA_A = CType(unaFila.Item(18), Double)
                c.CIT = CType(unaFila.Item(19), Integer)
                c.AGL = CType(unaFila.Item(20), Double)
                c.SNG = CType(unaFila.Item(21), Double)
                c.SFA = CType(unaFila.Item(22), Double)
                c.UFA = CType(unaFila.Item(23), Double)
                c.MUFA = CType(unaFila.Item(24), Double)
                c.PUFA = CType(unaFila.Item(25), Double)
                c.C16 = CType(unaFila.Item(26), Double)
                c.C180 = CType(unaFila.Item(27), Double)
                c.C181 = CType(unaFila.Item(28), Double)
                c.BHB = CType(unaFila.Item(29), Double)
                c.ACETONE = CType(unaFila.Item(30), Double)
                c.CISFAT = CType(unaFila.Item(31), Double)
                c.TRANSFAT = CType(unaFila.Item(32), Double)
                c.DENOVOFA = CType(unaFila.Item(33), Double)
                c.MIXEDFA = CType(unaFila.Item(34), Double)
                c.PREFORMEDFA = CType(unaFila.Item(35), Double)
                c.DENOVOFA2 = CType(unaFila.Item(36), Double)
                c.MIXEDFA2 = CType(unaFila.Item(37), Double)
                c.PREFORMEDFA2 = CType(unaFila.Item(38), Double)
                c.NEFA = CType(unaFila.Item(39), Double)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, grasa_b, grasa_a, cit, agl, sng, sfa, ufa, mufa, pufa, c16, c180, c181, bhb, acetone, cisfat, transfat, denovofa, mixedfa, preformedfa, denovofa2, mixedfa2, preformedfa2, nefa FROM calidad order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dImpCalidad2
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
                    c.GRASA_B = CType(unaFila.Item(17), Double)
                    c.GRASA_A = CType(unaFila.Item(18), Double)
                    c.CIT = CType(unaFila.Item(19), Integer)
                    c.AGL = CType(unaFila.Item(20), Double)
                    c.SNG = CType(unaFila.Item(21), Double)
                    c.SFA = CType(unaFila.Item(22), Double)
                    c.UFA = CType(unaFila.Item(23), Double)
                    c.MUFA = CType(unaFila.Item(24), Double)
                    c.PUFA = CType(unaFila.Item(25), Double)
                    c.C16 = CType(unaFila.Item(26), Double)
                    c.C180 = CType(unaFila.Item(27), Double)
                    c.C181 = CType(unaFila.Item(28), Double)
                    c.BHB = CType(unaFila.Item(29), Double)
                    c.ACETONE = CType(unaFila.Item(30), Double)
                    c.CISFAT = CType(unaFila.Item(31), Double)
                    c.TRANSFAT = CType(unaFila.Item(32), Double)
                    c.DENOVOFA = CType(unaFila.Item(33), Double)
                    c.MIXEDFA = CType(unaFila.Item(34), Double)
                    c.PREFORMEDFA = CType(unaFila.Item(35), Double)
                    c.DENOVOFA2 = CType(unaFila.Item(36), Double)
                    c.MIXEDFA2 = CType(unaFila.Item(37), Double)
                    c.PREFORMEDFA2 = CType(unaFila.Item(38), Double)
                    c.NEFA = CType(unaFila.Item(39), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, grasa_b, grasa_a, cit, agl, sng, sfa, ufa, mufa, pufa, c16, c180, c181, bhb, acetone, cisfat, transfat, denovofa, mixedfa, preformedfa, denovofa2, mixedfa2, preformedfa2, nefa FROM calidad where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dImpCalidad2
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
                    c.GRASA_B = CType(unaFila.Item(17), Double)
                    c.GRASA_A = CType(unaFila.Item(18), Double)
                    c.CIT = CType(unaFila.Item(19), Integer)
                    c.AGL = CType(unaFila.Item(20), Double)
                    c.SNG = CType(unaFila.Item(21), Double)
                    c.SFA = CType(unaFila.Item(22), Double)
                    c.UFA = CType(unaFila.Item(23), Double)
                    c.MUFA = CType(unaFila.Item(24), Double)
                    c.PUFA = CType(unaFila.Item(25), Double)
                    c.C16 = CType(unaFila.Item(26), Double)
                    c.C180 = CType(unaFila.Item(27), Double)
                    c.C181 = CType(unaFila.Item(28), Double)
                    c.BHB = CType(unaFila.Item(29), Double)
                    c.ACETONE = CType(unaFila.Item(30), Double)
                    c.CISFAT = CType(unaFila.Item(31), Double)
                    c.TRANSFAT = CType(unaFila.Item(32), Double)
                    c.DENOVOFA = CType(unaFila.Item(33), Double)
                    c.MIXEDFA = CType(unaFila.Item(34), Double)
                    c.PREFORMEDFA = CType(unaFila.Item(35), Double)
                    c.DENOVOFA2 = CType(unaFila.Item(36), Double)
                    c.MIXEDFA2 = CType(unaFila.Item(37), Double)
                    c.PREFORMEDFA2 = CType(unaFila.Item(38), Double)
                    c.NEFA = CType(unaFila.Item(39), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fecha, equipo, producto, muestra, rc, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, grasa_b, grasa_a, cit, agl, sng, sfa, ufa, mufa, pufa, c16, c180, c181, bhb, acetone, cisfat, transfat, denovofa, mixedfa, preformedfa, denovofa2, mixedfa2, preformedfa2, nefa FROM calidad where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dImpCalidad2
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
                    c.GRASA_B = CType(unaFila.Item(17), Double)
                    c.GRASA_A = CType(unaFila.Item(18), Double)
                    c.CIT = CType(unaFila.Item(19), Integer)
                    c.AGL = CType(unaFila.Item(20), Double)
                    c.SNG = CType(unaFila.Item(21), Double)
                    c.SFA = CType(unaFila.Item(22), Double)
                    c.UFA = CType(unaFila.Item(23), Double)
                    c.MUFA = CType(unaFila.Item(24), Double)
                    c.PUFA = CType(unaFila.Item(25), Double)
                    c.C16 = CType(unaFila.Item(26), Double)
                    c.C180 = CType(unaFila.Item(27), Double)
                    c.C181 = CType(unaFila.Item(28), Double)
                    c.BHB = CType(unaFila.Item(29), Double)
                    c.ACETONE = CType(unaFila.Item(30), Double)
                    c.CISFAT = CType(unaFila.Item(31), Double)
                    c.TRANSFAT = CType(unaFila.Item(32), Double)
                    c.DENOVOFA = CType(unaFila.Item(33), Double)
                    c.MIXEDFA = CType(unaFila.Item(34), Double)
                    c.PREFORMEDFA = CType(unaFila.Item(35), Double)
                    c.DENOVOFA2 = CType(unaFila.Item(36), Double)
                    c.MIXEDFA2 = CType(unaFila.Item(37), Double)
                    c.PREFORMEDFA2 = CType(unaFila.Item(38), Double)
                    c.NEFA = CType(unaFila.Item(39), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
