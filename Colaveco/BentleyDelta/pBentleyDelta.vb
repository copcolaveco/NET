Public Class pBentleyDelta
    Inherits Conectoras.ConexionMySQL_BentleyDelta
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dBentleyDelta = CType(o, dBentleyDelta)
        Dim sql As String = "INSERT INTO resultados (codigo, fecha, hora, id, equipo, mgr, gr1, gr2, grasa, mpr, pr1, pr2, proteina, mla, la1, la2, lactosa, mst, st1, st2, soltotales, mce, ce1, ce2, celulas, mcr, cr1, cr2, crioscopia, mur, ur1, ur2, urea, cgrasa, cproteina, clactosa, cstotales, ccelulas, ccrioscopia, curea, valido) VALUES (" & obj.CODIGO & ", '" & obj.FECHA & "', '" & obj.HORA & "'," & obj.ID & ",'" & obj.EQUIPO & "'," & obj.MGR & "," & obj.GR1 & "," & obj.GR2 & "," & obj.GRASA & "," & obj.MPR & "," & obj.PR1 & "," & obj.PR2 & "," & obj.PROTEINA & "," & obj.MLA & "," & obj.LA1 & "," & obj.LA2 & "," & obj.LACTOSA & "," & obj.MST & "," & obj.ST1 & "," & obj.ST2 & "," & obj.SOLTOTALES & "," & obj.MCE & "," & obj.CE1 & "," & obj.CE2 & "," & obj.CELULAS & "," & obj.MCR & "," & obj.CR1 & "," & obj.CR2 & "," & obj.CRIOSCOPIA & "," & obj.MUR & "," & obj.UR1 & "," & obj.UR2 & "," & obj.UREA & ",'" & obj.CGRASA & "','" & obj.CPROTEINA & "','" & obj.CLACTOSA & "','" & obj.CSTOTALES & "','" & obj.CCELULAS & "','" & obj.CCRIOSCOPIA & "','" & obj.CUREA & "','" & obj.VALIDO & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dBentleyDelta = CType(o, dBentleyDelta)
        Dim sql As String = "UPDATE resultados SET fecha = '" & obj.FECHA & "',hora= '" & obj.HORA & "',id=" & obj.ID & ",equipo='" & obj.EQUIPO & "',mgr=" & obj.MGR & ",gr1=" & obj.GR1 & ",gr2=" & obj.GR2 & ",grasa=" & obj.GRASA & ",mpr=" & obj.MPR & ",pr1=" & obj.PR1 & ",pr2=" & obj.PR2 & ",proteina=" & obj.PROTEINA & ",mla=" & obj.MLA & ",la1=" & obj.LA1 & ",la2=" & obj.LA2 & ",lactosa=" & obj.LACTOSA & ",mst=" & obj.MST & ",st1=" & obj.ST1 & ",st2=" & obj.ST2 & ",soltotales=" & obj.SOLTOTALES & ",mce=" & obj.MCE & ",ce1=" & obj.CE1 & ",ce2=" & obj.CE2 & ",celulas=" & obj.CELULAS & ",mcr=" & obj.MCR & ",cr1=" & obj.CR1 & ",cr2=" & obj.CR2 & ",crioscopia=" & obj.CRIOSCOPIA & ",mur=" & obj.MUR & ",ur1=" & obj.UR1 & ",ur2=" & obj.UR2 & ",urea=" & obj.UREA & ",cgrasa='" & obj.CGRASA & "',cproteina='" & obj.CPROTEINA & "',clactosa='" & obj.CLACTOSA & "',cstotales='" & obj.CSTOTALES & "',ccelulas='" & obj.CCELULAS & "',ccrioscopia='" & obj.CCRIOSCOPIA & "',curea='" & obj.CUREA & "',valido='" & obj.VALIDO & "' WHERE codigo = " & obj.CODIGO & ""

        Dim lista As New ArrayList
        lista.Add(sql)

       

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dBentleyDelta = CType(o, dBentleyDelta)
        Dim sql As String = "DELETE FROM resultados WHERE codigo = " & obj.CODIGO & ""

        Dim lista As New ArrayList
        lista.Add(sql)

       

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dBentleyDelta
        Dim obj As dBentleyDelta = CType(o, dBentleyDelta)
        Dim l As New dBentleyDelta
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT codigo, fecha, hora, id, equipo, mgr, gr1, gr2, grasa, mpr, pr1, pr2, proteina, mla, la1, la2, lactosa, mst, st1, st2, soltotales, mce, ce1, ce2, celulas, mcr, cr1, cr2, crioscopia, mur, ur1, ur2, urea, cgrasa, cproteina, clactosa, cstotales, ccelulas, ccrioscopia, curea, valido FROM resultados WHERE codigo = " & obj.CODIGO & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.CODIGO = CType(unaFila.Item(0), Long)
                l.FECHA = CType(unaFila.Item(1), String)
                l.HORA = CType(unaFila.Item(2), String)
                l.ID = CType(unaFila.Item(3), Double)
                l.EQUIPO = CType(unaFila.Item(4), String)
                l.MGR = CType(unaFila.Item(5), Double)
                l.GR1 = CType(unaFila.Item(6), Double)
                l.GR2 = CType(unaFila.Item(7), Double)
                l.GRASA = CType(unaFila.Item(8), Double)
                l.MPR = CType(unaFila.Item(9), Double)
                l.PR1 = CType(unaFila.Item(10), Double)
                l.PR2 = CType(unaFila.Item(11), Double)
                l.PROTEINA = CType(unaFila.Item(12), Double)
                l.MLA = CType(unaFila.Item(13), Double)
                l.LA1 = CType(unaFila.Item(14), Double)
                l.LA2 = CType(unaFila.Item(15), Double)
                l.LACTOSA = CType(unaFila.Item(16), Double)
                l.MST = CType(unaFila.Item(17), Double)
                l.ST1 = CType(unaFila.Item(18), Double)
                l.ST2 = CType(unaFila.Item(19), Double)
                l.SOLTOTALES = CType(unaFila.Item(20), Double)
                l.MCE = CType(unaFila.Item(21), Double)
                l.CE1 = CType(unaFila.Item(22), Double)
                l.CE2 = CType(unaFila.Item(23), Double)
                l.CELULAS = CType(unaFila.Item(24), Long)
                l.MCR = CType(unaFila.Item(25), Double)
                l.CR1 = CType(unaFila.Item(26), Double)
                l.CR2 = CType(unaFila.Item(27), Double)
                l.CRIOSCOPIA = CType(unaFila.Item(28), Long)
                l.MUR = CType(unaFila.Item(29), Double)
                l.UR1 = CType(unaFila.Item(30), Double)
                l.UR2 = CType(unaFila.Item(31), Double)
                l.UREA = CType(unaFila.Item(32), Integer)
                l.CGRASA = CType(unaFila.Item(33), String)
                l.CPROTEINA = CType(unaFila.Item(34), String)
                l.CLACTOSA = CType(unaFila.Item(35), String)
                l.CSTOTALES = CType(unaFila.Item(36), String)
                l.CCELULAS = CType(unaFila.Item(37), String)
                l.CCRIOSCOPIA = CType(unaFila.Item(38), String)
                l.CUREA = CType(unaFila.Item(39), String)
                l.VALIDO = CType(unaFila.Item(40), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT codigo, fecha, hora, id, equipo, mgr, gr1, gr2, grasa, mpr, pr1, pr2, proteina, mla, la1, la2, lactosa, mst, st1, st2, soltotales, mce, ce1, ce2, celulas, mcr, cr1, cr2, crioscopia, mur, ur1, ur2, urea, cgrasa, cproteina, clactosa, cstotales, ccelulas, ccrioscopia, curea, valido FROM resultados"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dBentleyDelta
                    l.CODIGO = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.HORA = CType(unaFila.Item(2), String)
                    l.ID = CType(unaFila.Item(3), Double)
                    l.EQUIPO = CType(unaFila.Item(4), String)
                    l.MGR = CType(unaFila.Item(5), Double)
                    l.GR1 = CType(unaFila.Item(6), Double)
                    l.GR2 = CType(unaFila.Item(7), Double)
                    l.GRASA = CType(unaFila.Item(8), Double)
                    l.MPR = CType(unaFila.Item(9), Double)
                    l.PR1 = CType(unaFila.Item(10), Double)
                    l.PR2 = CType(unaFila.Item(11), Double)
                    l.PROTEINA = CType(unaFila.Item(12), Double)
                    l.MLA = CType(unaFila.Item(13), Double)
                    l.LA1 = CType(unaFila.Item(14), Double)
                    l.LA2 = CType(unaFila.Item(15), Double)
                    l.LACTOSA = CType(unaFila.Item(16), Double)
                    l.MST = CType(unaFila.Item(17), Double)
                    l.ST1 = CType(unaFila.Item(18), Double)
                    l.ST2 = CType(unaFila.Item(19), Double)
                    l.SOLTOTALES = CType(unaFila.Item(20), Double)
                    l.MCE = CType(unaFila.Item(21), Double)
                    l.CE1 = CType(unaFila.Item(22), Double)
                    l.CE2 = CType(unaFila.Item(23), Double)
                    l.CELULAS = CType(unaFila.Item(24), Long)
                    l.MCR = CType(unaFila.Item(25), Double)
                    l.CR1 = CType(unaFila.Item(26), Double)
                    l.CR2 = CType(unaFila.Item(27), Double)
                    l.CRIOSCOPIA = CType(unaFila.Item(28), Long)
                    l.MUR = CType(unaFila.Item(29), Double)
                    l.UR1 = CType(unaFila.Item(30), Double)
                    l.UR2 = CType(unaFila.Item(31), Double)
                    l.UREA = CType(unaFila.Item(32), Integer)
                    l.CGRASA = CType(unaFila.Item(33), String)
                    l.CPROTEINA = CType(unaFila.Item(34), String)
                    l.CLACTOSA = CType(unaFila.Item(35), String)
                    l.CSTOTALES = CType(unaFila.Item(36), String)
                    l.CCELULAS = CType(unaFila.Item(37), String)
                    l.CCRIOSCOPIA = CType(unaFila.Item(38), String)
                    l.CUREA = CType(unaFila.Item(39), String)
                    l.VALIDO = CType(unaFila.Item(40), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinvalidar() As ArrayList
        Dim sql As String = "SELECT codigo, fecha, hora, id, equipo, mgr, gr1, gr2, grasa, mpr, pr1, pr2, proteina, mla, la1, la2, lactosa, mst, st1, st2, soltotales, mce, ce1, ce2, celulas, mcr, cr1, cr2, crioscopia, mur, ur1, ur2, urea, cgrasa, cproteina, clactosa, cstotales, ccelulas, ccrioscopia, curea, valido FROM resultados WHERE valido = 'n' ORDER BY fecha, hora ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dBentleyDelta
                    l.CODIGO = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.HORA = CType(unaFila.Item(2), String)
                    l.ID = CType(unaFila.Item(3), Double)
                    l.EQUIPO = CType(unaFila.Item(4), String)
                    l.MGR = CType(unaFila.Item(5), Double)
                    l.GR1 = CType(unaFila.Item(6), Double)
                    l.GR2 = CType(unaFila.Item(7), Double)
                    l.GRASA = CType(unaFila.Item(8), Double)
                    l.MPR = CType(unaFila.Item(9), Double)
                    l.PR1 = CType(unaFila.Item(10), Double)
                    l.PR2 = CType(unaFila.Item(11), Double)
                    l.PROTEINA = CType(unaFila.Item(12), Double)
                    l.MLA = CType(unaFila.Item(13), Double)
                    l.LA1 = CType(unaFila.Item(14), Double)
                    l.LA2 = CType(unaFila.Item(15), Double)
                    l.LACTOSA = CType(unaFila.Item(16), Double)
                    l.MST = CType(unaFila.Item(17), Double)
                    l.ST1 = CType(unaFila.Item(18), Double)
                    l.ST2 = CType(unaFila.Item(19), Double)
                    l.SOLTOTALES = CType(unaFila.Item(20), Double)
                    l.MCE = CType(unaFila.Item(21), Double)
                    l.CE1 = CType(unaFila.Item(22), Double)
                    l.CE2 = CType(unaFila.Item(23), Double)
                    l.CELULAS = CType(unaFila.Item(24), Long)
                    l.MCR = CType(unaFila.Item(25), Double)
                    l.CR1 = CType(unaFila.Item(26), Double)
                    l.CR2 = CType(unaFila.Item(27), Double)
                    l.CRIOSCOPIA = CType(unaFila.Item(28), Long)
                    l.MUR = CType(unaFila.Item(29), Double)
                    l.UR1 = CType(unaFila.Item(30), Double)
                    l.UR2 = CType(unaFila.Item(31), Double)
                    l.UREA = CType(unaFila.Item(32), Integer)
                    l.CGRASA = CType(unaFila.Item(33), String)
                    l.CPROTEINA = CType(unaFila.Item(34), String)
                    l.CLACTOSA = CType(unaFila.Item(35), String)
                    l.CSTOTALES = CType(unaFila.Item(36), String)
                    l.CCELULAS = CType(unaFila.Item(37), String)
                    l.CCRIOSCOPIA = CType(unaFila.Item(38), String)
                    l.CUREA = CType(unaFila.Item(39), String)
                    l.VALIDO = CType(unaFila.Item(40), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT codigo, fecha, hora, id, equipo, mgr, gr1, gr2, grasa, mpr, pr1, pr2, proteina, mla, la1, la2, lactosa, mst, st1, st2, soltotales, mce, ce1, ce2, celulas, mcr, cr1, cr2, crioscopia, mur, ur1, ur2, urea, cgrasa, cproteina, clactosa, cstotales, ccelulas, ccrioscopia, curea, valido FROM resultados WHERE fecha BETWEEN '" & desde & "' and '" & hasta & "' ORDER BY fecha, hora ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dBentleyDelta
                    l.CODIGO = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.HORA = CType(unaFila.Item(2), String)
                    l.ID = CType(unaFila.Item(3), Double)
                    l.EQUIPO = CType(unaFila.Item(4), String)
                    l.MGR = CType(unaFila.Item(5), Double)
                    l.GR1 = CType(unaFila.Item(6), Double)
                    l.GR2 = CType(unaFila.Item(7), Double)
                    l.GRASA = CType(unaFila.Item(8), Double)
                    l.MPR = CType(unaFila.Item(9), Double)
                    l.PR1 = CType(unaFila.Item(10), Double)
                    l.PR2 = CType(unaFila.Item(11), Double)
                    l.PROTEINA = CType(unaFila.Item(12), Double)
                    l.MLA = CType(unaFila.Item(13), Double)
                    l.LA1 = CType(unaFila.Item(14), Double)
                    l.LA2 = CType(unaFila.Item(15), Double)
                    l.LACTOSA = CType(unaFila.Item(16), Double)
                    l.MST = CType(unaFila.Item(17), Double)
                    l.ST1 = CType(unaFila.Item(18), Double)
                    l.ST2 = CType(unaFila.Item(19), Double)
                    l.SOLTOTALES = CType(unaFila.Item(20), Double)
                    l.MCE = CType(unaFila.Item(21), Double)
                    l.CE1 = CType(unaFila.Item(22), Double)
                    l.CE2 = CType(unaFila.Item(23), Double)
                    l.CELULAS = CType(unaFila.Item(24), Long)
                    l.MCR = CType(unaFila.Item(25), Double)
                    l.CR1 = CType(unaFila.Item(26), Double)
                    l.CR2 = CType(unaFila.Item(27), Double)
                    l.CRIOSCOPIA = CType(unaFila.Item(28), Long)
                    l.MUR = CType(unaFila.Item(29), Double)
                    l.UR1 = CType(unaFila.Item(30), Double)
                    l.UR2 = CType(unaFila.Item(31), Double)
                    l.UREA = CType(unaFila.Item(32), Integer)
                    l.CGRASA = CType(unaFila.Item(33), String)
                    l.CPROTEINA = CType(unaFila.Item(34), String)
                    l.CLACTOSA = CType(unaFila.Item(35), String)
                    l.CSTOTALES = CType(unaFila.Item(36), String)
                    l.CCELULAS = CType(unaFila.Item(37), String)
                    l.CCRIOSCOPIA = CType(unaFila.Item(38), String)
                    l.CUREA = CType(unaFila.Item(39), String)
                    l.VALIDO = CType(unaFila.Item(40), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function validar(ByVal o As Object) As Boolean
        Dim obj As dBentleyDelta = CType(o, dBentleyDelta)
        Dim sql As String = "UPDATE resultados SET valido='s' WHERE valido='n' and codigo = " & obj.CODIGO & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
End Class