Public Class pAgua
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAgua = CType(o, dAgua)
        Dim sql As String = "INSERT INTO analisisdeagua (id, ficha, fechaentrada, idtipopozo, antiguedad, distanciapozonegro, distanciatambo, envasada, idmuestraextraida, idmuestrafueracondicion, profundidad, idaguatratada, idestadodeconservacion, het22, het35, het37, cloro, conductividad, ph, ecoli, sulfitoreductores, enterococos, estreptococos, marca, muestraoficial, precinto, paqmacro, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, alcalinidad,refrendacion_tambo) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.FECHAENTRADA & "', " & obj.IDTIPOPOZO & ", " & obj.ANTIGUEDAD & ", " & obj.DISTANCIAPOZONEGRO & "," & obj.DISTANCIATAMBO & ", " & obj.ENVASADA & "," & obj.IDMUESTRAEXTRAIDA & ", " & obj.IDMUESTRAFUERACONDICION & ", " & obj.PROFUNDIDAD & ", " & obj.IDAGUATRATADA & ", " & obj.IDESTADODECONSERVACION & ", " & obj.HET22 & "," & obj.HET35 & "," & obj.HET37 & "," & obj.CLORO & "," & obj.CONDUCTIVIDAD & "," & obj.PH & "," & obj.ECOLI & "," & obj.SULFITOREDUCTORES & "," & obj.ENTEROCOCOS & "," & obj.ESTREPTOCOCOS & "," & obj.MARCA & ", " & obj.MUESTRAOFICIAL & ", '" & obj.PRECINTO & "', " & obj.PAQMACRO & ", " & obj.CA & ", " & obj.MG & ", " & obj.NA & ", " & obj.FE & ", " & obj.K & ", " & obj.AL & ", " & obj.CD & ", " & obj.CR & ", " & obj.CU & ", " & obj.PB & ", " & obj.MN & ", " & obj.FEM & ", " & obj.ZN & ", " & obj.SE & ", " & obj.ALCALINIDAD & ", " & obj.REFRENDACION_TAMBO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisisdeagua', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAgua = CType(o, dAgua)
        Dim sql As String = "UPDATE analisisdeagua SET ficha = " & obj.FICHA & ",  fechaentrada ='" & obj.FECHAENTRADA & "', idtipopozo=" & obj.IDTIPOPOZO & ",antiguedad=" & obj.ANTIGUEDAD & ",distanciapozonegro=" & obj.DISTANCIAPOZONEGRO & ",distanciatambo=" & obj.DISTANCIATAMBO & ",envasada=" & obj.ENVASADA & ",idmuestraextraida=" & obj.IDMUESTRAEXTRAIDA & ", idmuestrafueracondicion=" & obj.IDMUESTRAFUERACONDICION & ", profundidad=" & obj.PROFUNDIDAD & ", idaguatratada=" & obj.IDAGUATRATADA & ", idestadodeconservacion=" & obj.IDESTADODECONSERVACION & ",het22=" & obj.HET22 & ",het35=" & obj.HET35 & ", het37=" & obj.HET37 & ",cloro=" & obj.CLORO & ",conductividad=" & obj.CONDUCTIVIDAD & ",ph=" & obj.PH & ",ecoli=" & obj.ECOLI & ", sulfitoreductores=" & obj.SULFITOREDUCTORES & ",enterococos=" & obj.ENTEROCOCOS & ",estreptococos=" & obj.ESTREPTOCOCOS & ", marca=" & obj.MARCA & ",muestraoficial=" & obj.MUESTRAOFICIAL & ",precinto='" & obj.PRECINTO & "',paqmacro=" & obj.PAQMACRO & ",ca=" & obj.CA & ",mg=" & obj.MG & ",na=" & obj.NA & ",fe=" & obj.FE & ",k=" & obj.K & ",al=" & obj.AL & ",cd=" & obj.CD & ",cr=" & obj.CR & ", cu=" & obj.CU & ", pb=" & obj.PB & ", mn=" & obj.MN & ", fem=" & obj.FEM & ", zn=" & obj.ZN & ", se=" & obj.SE & ", alcalinidad=" & obj.ALCALINIDAD & "  WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisisdeagua', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAgua = CType(o, dAgua)
        Dim sql As String = "DELETE FROM analisisdeagua WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisisdeagua', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAgua
        Dim obj As dAgua = CType(o, dAgua)
        Dim a As New dAgua
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fechaentrada, idtipopozo, antiguedad, distanciapozonegro, distanciatambo, envasada, idmuestraextraida, idmuestrafueracondicion, profundidad, idaguatratada, idestadodeconservacion, het22, het35, het37, cloro, conductividad, ph, ecoli, sulfitoreductores, enterococos, estreptococos, marca, muestraoficial, precinto, paqmacro, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, alcalinidad, refrendacion_tambo FROM analisisdeagua WHERE ficha = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                a.ID = CType(unaFila.Item(0), Long)
                a.FICHA = CType(unaFila.Item(1), Long)
                a.FECHAENTRADA = CType(unaFila.Item(2), String)
                a.IDTIPOPOZO = CType(unaFila.Item(3), Integer)
                a.ANTIGUEDAD = CType(unaFila.Item(4), Double)
                a.DISTANCIAPOZONEGRO = CType(unaFila.Item(5), Double)
                a.DISTANCIATAMBO = CType(unaFila.Item(6), Double)
                a.ENVASADA = CType(unaFila.Item(7), Integer)
                a.IDMUESTRAEXTRAIDA = CType(unaFila.Item(8), Integer)
                a.IDMUESTRAFUERACONDICION = CType(unaFila.Item(9), Integer)
                a.PROFUNDIDAD = CType(unaFila.Item(10), Integer)
                a.IDAGUATRATADA = CType(unaFila.Item(11), Integer)
                a.IDESTADODECONSERVACION = CType(unaFila.Item(12), Integer)
                a.HET22 = CType(unaFila.Item(13), Integer)
                a.HET35 = CType(unaFila.Item(14), Integer)
                a.HET37 = CType(unaFila.Item(15), Integer)
                a.CLORO = CType(unaFila.Item(16), Integer)
                a.CONDUCTIVIDAD = CType(unaFila.Item(17), Integer)
                a.PH = CType(unaFila.Item(18), Integer)
                a.ECOLI = CType(unaFila.Item(19), Integer)
                a.SULFITOREDUCTORES = CType(unaFila.Item(20), Integer)
                a.ENTEROCOCOS = CType(unaFila.Item(21), Integer)
                a.ESTREPTOCOCOS = CType(unaFila.Item(22), Integer)
                a.MARCA = CType(unaFila.Item(23), Integer)
                a.MUESTRAOFICIAL = CType(unaFila.Item(24), Integer)
                a.PRECINTO = CType(unaFila.Item(25), String)
                a.PAQMACRO = CType(unaFila.Item(26), Integer)
                a.CA = CType(unaFila.Item(27), Integer)
                a.MG = CType(unaFila.Item(28), Integer)
                a.NA = CType(unaFila.Item(29), Integer)
                a.FE = CType(unaFila.Item(30), Integer)
                a.K = CType(unaFila.Item(31), Integer)
                a.AL = CType(unaFila.Item(32), Integer)
                a.CD = CType(unaFila.Item(33), Integer)
                a.CR = CType(unaFila.Item(34), Integer)
                a.CU = CType(unaFila.Item(35), Integer)
                a.PB = CType(unaFila.Item(36), Integer)
                a.MN = CType(unaFila.Item(37), Integer)
                a.FEM = CType(unaFila.Item(38), Integer)
                a.ZN = CType(unaFila.Item(39), Integer)
                a.SE = CType(unaFila.Item(40), Integer)
                a.ALCALINIDAD = CType(unaFila.Item(41), Integer)
                a.REFRENDACION_TAMBO = CType(unaFila.Item(42), Integer)
                Return a
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function tieneRefrendacionTambo(ByVal fichaId As Long) As Boolean
        Dim sql As String = "SELECT refrendacion_tambo FROM analisisdeagua WHERE ficha = " & fichaId
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count > 0 Then
                ' Verifica si alguno tiene refrendacion_tambo = 1
                For Each fila As DataRow In Ds.Tables(0).Rows
                    If Not IsDBNull(fila("refrendacion_tambo")) AndAlso CType(fila("refrendacion_tambo"), Integer) = 1 Then
                        Return True
                    End If
                Next
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function buscarxficha(ByVal o As Object) As dAgua
        Dim obj As dAgua = CType(o, dAgua)
        Dim a As New dAgua
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fechaentrada, idtipopozo, antiguedad, distanciapozonegro, distanciatambo, envasada, idmuestraextraida, idmuestrafueracondicion, profundidad, idaguatratada, idestadodeconservacion, het22, het35, het37, cloro, conductividad, ph, ecoli, sulfitoreductores, enterococos, estreptococos, marca, muestraoficial, precinto, paqmacro, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, alcalinidad,refrendacion_tambo FROM analisisdeagua WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                a.ID = CType(unaFila.Item(0), Long)
                a.FICHA = CType(unaFila.Item(1), Long)
                a.FECHAENTRADA = CType(unaFila.Item(2), String)
                a.IDTIPOPOZO = CType(unaFila.Item(3), Integer)
                a.ANTIGUEDAD = CType(unaFila.Item(4), Double)
                a.DISTANCIAPOZONEGRO = CType(unaFila.Item(5), Double)
                a.DISTANCIATAMBO = CType(unaFila.Item(6), Double)
                a.ENVASADA = CType(unaFila.Item(7), Integer)
                a.IDMUESTRAEXTRAIDA = CType(unaFila.Item(8), Integer)
                a.IDMUESTRAFUERACONDICION = CType(unaFila.Item(9), Integer)
                a.PROFUNDIDAD = CType(unaFila.Item(10), Integer)
                a.IDAGUATRATADA = CType(unaFila.Item(11), Integer)
                a.IDESTADODECONSERVACION = CType(unaFila.Item(12), Integer)
                a.HET22 = CType(unaFila.Item(13), Integer)
                a.HET35 = CType(unaFila.Item(14), Integer)
                a.HET37 = CType(unaFila.Item(15), Integer)
                a.CLORO = CType(unaFila.Item(16), Integer)
                a.CONDUCTIVIDAD = CType(unaFila.Item(17), Integer)
                a.PH = CType(unaFila.Item(18), Integer)
                a.ECOLI = CType(unaFila.Item(19), Integer)
                a.SULFITOREDUCTORES = CType(unaFila.Item(20), Integer)
                a.ENTEROCOCOS = CType(unaFila.Item(21), Integer)
                a.ESTREPTOCOCOS = CType(unaFila.Item(22), Integer)
                a.MARCA = CType(unaFila.Item(23), Integer)
                a.MUESTRAOFICIAL = CType(unaFila.Item(24), Integer)
                a.PRECINTO = CType(unaFila.Item(25), String)
                a.PAQMACRO = CType(unaFila.Item(26), Integer)
                a.CA = CType(unaFila.Item(27), Integer)
                a.MG = CType(unaFila.Item(28), Integer)
                a.NA = CType(unaFila.Item(29), Integer)
                a.FE = CType(unaFila.Item(30), Integer)
                a.K = CType(unaFila.Item(31), Integer)
                a.AL = CType(unaFila.Item(32), Integer)
                a.CD = CType(unaFila.Item(33), Integer)
                a.CR = CType(unaFila.Item(34), Integer)
                a.CU = CType(unaFila.Item(35), Integer)
                a.PB = CType(unaFila.Item(36), Integer)
                a.MN = CType(unaFila.Item(37), Integer)
                a.FEM = CType(unaFila.Item(38), Integer)
                a.ZN = CType(unaFila.Item(39), Integer)
                a.SE = CType(unaFila.Item(40), Integer)
                a.ALCALINIDAD = CType(unaFila.Item(41), Integer)
                a.REFRENDACION_TAMBO = CType(unaFila.Item(42), Integer)
                Return a
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fechaentrada, idtipopozo, antiguedad, distanciapozonegro, distanciatambo, envasada, idmuestraextraida, idmuestrafueracondicion, profundidad, idaguatratada, idestadodeconservacion, het22, het35, het37, cloro, conductividad, ph, ecoli, sulfitoreductores, enterococos, estreptococos, marca, muestraoficial, precinto, paqmacro, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, alcalinidad,refrendacion_tambo FROM analisisdeagua WHERE marca = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.IDTIPOPOZO = CType(unaFila.Item(3), Integer)
                    a.ANTIGUEDAD = CType(unaFila.Item(4), Double)
                    a.DISTANCIAPOZONEGRO = CType(unaFila.Item(5), Double)
                    a.DISTANCIATAMBO = CType(unaFila.Item(6), Double)
                    a.ENVASADA = CType(unaFila.Item(7), Integer)
                    a.IDMUESTRAEXTRAIDA = CType(unaFila.Item(8), Integer)
                    a.IDMUESTRAFUERACONDICION = CType(unaFila.Item(9), Integer)
                    a.PROFUNDIDAD = CType(unaFila.Item(10), Integer)
                    a.IDAGUATRATADA = CType(unaFila.Item(11), Integer)
                    a.IDESTADODECONSERVACION = CType(unaFila.Item(12), Integer)
                    a.HET22 = CType(unaFila.Item(13), Integer)
                    a.HET35 = CType(unaFila.Item(14), Integer)
                    a.HET37 = CType(unaFila.Item(15), Integer)
                    a.CLORO = CType(unaFila.Item(16), Integer)
                    a.CONDUCTIVIDAD = CType(unaFila.Item(17), Integer)
                    a.PH = CType(unaFila.Item(18), Integer)
                    a.ECOLI = CType(unaFila.Item(19), Integer)
                    a.SULFITOREDUCTORES = CType(unaFila.Item(20), Integer)
                    a.ENTEROCOCOS = CType(unaFila.Item(21), Integer)
                    a.ESTREPTOCOCOS = CType(unaFila.Item(22), Integer)
                    a.MARCA = CType(unaFila.Item(23), Integer)
                    a.MUESTRAOFICIAL = CType(unaFila.Item(24), Integer)
                    a.PRECINTO = CType(unaFila.Item(25), String)
                    a.PAQMACRO = CType(unaFila.Item(26), Integer)
                    a.CA = CType(unaFila.Item(27), Integer)
                    a.MG = CType(unaFila.Item(28), Integer)
                    a.NA = CType(unaFila.Item(29), Integer)
                    a.FE = CType(unaFila.Item(30), Integer)
                    a.K = CType(unaFila.Item(31), Integer)
                    a.AL = CType(unaFila.Item(32), Integer)
                    a.CD = CType(unaFila.Item(33), Integer)
                    a.CR = CType(unaFila.Item(34), Integer)
                    a.CU = CType(unaFila.Item(35), Integer)
                    a.PB = CType(unaFila.Item(36), Integer)
                    a.MN = CType(unaFila.Item(37), Integer)
                    a.FEM = CType(unaFila.Item(38), Integer)
                    a.ZN = CType(unaFila.Item(39), Integer)
                    a.SE = CType(unaFila.Item(40), Integer)
                    a.ALCALINIDAD = CType(unaFila.Item(41), Integer)
                    a.REFRENDACION_TAMBO = CType(unaFila.Item(42), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM analisisdeagua WHERE marca = 0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua
                    a.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, idtipopozo, antiguedad, distanciapozonegro, distanciatambo, envasada, idmuestraextraida, idmuestrafueracondicion, profundidad, idaguatratada, idestadodeconservacion, het22, het35, het37, cloro, conductividad, ph, ecoli, sulfitoreductores, enterococos, estreptococos, marca, muestraoficial, precinto, paqmacro, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, alcalinidad,refrendacion_tambo FROM analisisdeagua where ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.IDTIPOPOZO = CType(unaFila.Item(3), Integer)
                    a.ANTIGUEDAD = CType(unaFila.Item(4), Double)
                    a.DISTANCIAPOZONEGRO = CType(unaFila.Item(5), Double)
                    a.DISTANCIATAMBO = CType(unaFila.Item(6), Double)
                    a.ENVASADA = CType(unaFila.Item(7), Integer)
                    a.IDMUESTRAEXTRAIDA = CType(unaFila.Item(8), Integer)
                    a.IDMUESTRAFUERACONDICION = CType(unaFila.Item(9), Integer)
                    a.PROFUNDIDAD = CType(unaFila.Item(10), Integer)
                    a.IDAGUATRATADA = CType(unaFila.Item(11), Integer)
                    a.IDESTADODECONSERVACION = CType(unaFila.Item(12), Integer)
                    a.HET22 = CType(unaFila.Item(13), Integer)
                    a.HET35 = CType(unaFila.Item(14), Integer)
                    a.HET37 = CType(unaFila.Item(15), Integer)
                    a.CLORO = CType(unaFila.Item(16), Integer)
                    a.CONDUCTIVIDAD = CType(unaFila.Item(17), Integer)
                    a.PH = CType(unaFila.Item(18), Integer)
                    a.ECOLI = CType(unaFila.Item(19), Integer)
                    a.SULFITOREDUCTORES = CType(unaFila.Item(20), Integer)
                    a.ENTEROCOCOS = CType(unaFila.Item(21), Integer)
                    a.ESTREPTOCOCOS = CType(unaFila.Item(22), Integer)
                    a.MARCA = CType(unaFila.Item(23), Integer)
                    a.MUESTRAOFICIAL = CType(unaFila.Item(24), Integer)
                    a.PRECINTO = CType(unaFila.Item(25), String)
                    a.PAQMACRO = CType(unaFila.Item(26), Integer)
                    a.CA = CType(unaFila.Item(27), Integer)
                    a.MG = CType(unaFila.Item(28), Integer)
                    a.NA = CType(unaFila.Item(29), Integer)
                    a.FE = CType(unaFila.Item(30), Integer)
                    a.K = CType(unaFila.Item(31), Integer)
                    a.AL = CType(unaFila.Item(32), Integer)
                    a.CD = CType(unaFila.Item(33), Integer)
                    a.CR = CType(unaFila.Item(34), Integer)
                    a.CU = CType(unaFila.Item(35), Integer)
                    a.PB = CType(unaFila.Item(36), Integer)
                    a.MN = CType(unaFila.Item(37), Integer)
                    a.FEM = CType(unaFila.Item(38), Integer)
                    a.ZN = CType(unaFila.Item(39), Integer)
                    a.SE = CType(unaFila.Item(40), Integer)
                    a.ALCALINIDAD = CType(unaFila.Item(41), Integer)
                    a.REFRENDACION_TAMBO = CType(unaFila.Item(42), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, idtipopozo, antiguedad, distanciapozonegro, distanciatambo, envasada, idmuestraextraida, idmuestrafueracondicion, profundidad, idaguatratada, idestadodeconservacion, het22, het35, het37, cloro, conductividad, ph, ecoli, sulfitoreductores, enterococos, estreptococos, marca, muestraoficial, precinto, paqmacro, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, alcalinidad,refrendacion_tambo FROM analisisdeagua where marca = 0 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.IDTIPOPOZO = CType(unaFila.Item(3), Integer)
                    a.ANTIGUEDAD = CType(unaFila.Item(4), Double)
                    a.DISTANCIAPOZONEGRO = CType(unaFila.Item(5), Double)
                    a.DISTANCIATAMBO = CType(unaFila.Item(6), Double)
                    a.ENVASADA = CType(unaFila.Item(7), Integer)
                    a.IDMUESTRAEXTRAIDA = CType(unaFila.Item(8), Integer)
                    a.IDMUESTRAFUERACONDICION = CType(unaFila.Item(9), Integer)
                    a.PROFUNDIDAD = CType(unaFila.Item(10), Integer)
                    a.IDAGUATRATADA = CType(unaFila.Item(11), Integer)
                    a.IDESTADODECONSERVACION = CType(unaFila.Item(12), Integer)
                    a.HET22 = CType(unaFila.Item(13), Integer)
                    a.HET35 = CType(unaFila.Item(14), Integer)
                    a.HET37 = CType(unaFila.Item(15), Integer)
                    a.CLORO = CType(unaFila.Item(16), Integer)
                    a.CONDUCTIVIDAD = CType(unaFila.Item(17), Integer)
                    a.PH = CType(unaFila.Item(18), Integer)
                    a.ECOLI = CType(unaFila.Item(19), Integer)
                    a.SULFITOREDUCTORES = CType(unaFila.Item(20), Integer)
                    a.ENTEROCOCOS = CType(unaFila.Item(21), Integer)
                    a.ESTREPTOCOCOS = CType(unaFila.Item(22), Integer)
                    a.MARCA = CType(unaFila.Item(23), Integer)
                    a.MUESTRAOFICIAL = CType(unaFila.Item(24), Integer)
                    a.PRECINTO = CType(unaFila.Item(25), String)
                    a.PAQMACRO = CType(unaFila.Item(26), Integer)
                    a.CA = CType(unaFila.Item(27), Integer)
                    a.MG = CType(unaFila.Item(28), Integer)
                    a.NA = CType(unaFila.Item(29), Integer)
                    a.FE = CType(unaFila.Item(30), Integer)
                    a.K = CType(unaFila.Item(31), Integer)
                    a.AL = CType(unaFila.Item(32), Integer)
                    a.CD = CType(unaFila.Item(33), Integer)
                    a.CR = CType(unaFila.Item(34), Integer)
                    a.CU = CType(unaFila.Item(35), Integer)
                    a.PB = CType(unaFila.Item(36), Integer)
                    a.MN = CType(unaFila.Item(37), Integer)
                    a.FEM = CType(unaFila.Item(38), Integer)
                    a.ZN = CType(unaFila.Item(39), Integer)
                    a.SE = CType(unaFila.Item(40), Integer)
                    a.ALCALINIDAD = CType(unaFila.Item(41), Integer)
                    a.REFRENDACION_TAMBO = CType(unaFila.Item(42), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, idtipopozo, antiguedad, distanciapozonegro, distanciatambo, envasada, idmuestraextraida, idmuestrafueracondicion, profundidad, idaguatratada, idestadodeconservacion, het22, het35, het37, cloro, conductividad, ph, ecoli, sulfitoreductores, enterococos, estreptococos, marca, muestraoficial, precinto, paqmacro, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, alcalinidad,refrendacion_tambo FROM analisisdeagua where marca = 1 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.IDTIPOPOZO = CType(unaFila.Item(3), Integer)
                    a.ANTIGUEDAD = CType(unaFila.Item(4), Double)
                    a.DISTANCIAPOZONEGRO = CType(unaFila.Item(5), Double)
                    a.DISTANCIATAMBO = CType(unaFila.Item(6), Double)
                    a.ENVASADA = CType(unaFila.Item(7), Integer)
                    a.IDMUESTRAEXTRAIDA = CType(unaFila.Item(8), Integer)
                    a.IDMUESTRAFUERACONDICION = CType(unaFila.Item(9), Integer)
                    a.PROFUNDIDAD = CType(unaFila.Item(10), Integer)
                    a.IDAGUATRATADA = CType(unaFila.Item(11), Integer)
                    a.IDESTADODECONSERVACION = CType(unaFila.Item(12), Integer)
                    a.HET22 = CType(unaFila.Item(13), Integer)
                    a.HET35 = CType(unaFila.Item(14), Integer)
                    a.HET37 = CType(unaFila.Item(15), Integer)
                    a.CLORO = CType(unaFila.Item(16), Integer)
                    a.CONDUCTIVIDAD = CType(unaFila.Item(17), Integer)
                    a.PH = CType(unaFila.Item(18), Integer)
                    a.ECOLI = CType(unaFila.Item(19), Integer)
                    a.SULFITOREDUCTORES = CType(unaFila.Item(20), Integer)
                    a.ENTEROCOCOS = CType(unaFila.Item(21), Integer)
                    a.ESTREPTOCOCOS = CType(unaFila.Item(22), Integer)
                    a.MARCA = CType(unaFila.Item(23), Integer)
                    a.MUESTRAOFICIAL = CType(unaFila.Item(24), Integer)
                    a.PRECINTO = CType(unaFila.Item(25), String)
                    a.PAQMACRO = CType(unaFila.Item(26), Integer)
                    a.CA = CType(unaFila.Item(27), Integer)
                    a.MG = CType(unaFila.Item(28), Integer)
                    a.NA = CType(unaFila.Item(29), Integer)
                    a.FE = CType(unaFila.Item(30), Integer)
                    a.K = CType(unaFila.Item(31), Integer)
                    a.AL = CType(unaFila.Item(32), Integer)
                    a.CD = CType(unaFila.Item(33), Integer)
                    a.CR = CType(unaFila.Item(34), Integer)
                    a.CU = CType(unaFila.Item(35), Integer)
                    a.PB = CType(unaFila.Item(36), Integer)
                    a.MN = CType(unaFila.Item(37), Integer)
                    a.FEM = CType(unaFila.Item(38), Integer)
                    a.ZN = CType(unaFila.Item(39), Integer)
                    a.SE = CType(unaFila.Item(40), Integer)
                    a.ALCALINIDAD = CType(unaFila.Item(41), Integer)
                    a.REFRENDACION_TAMBO = CType(unaFila.Item(42), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, idtipopozo, antiguedad, distanciapozonegro, distanciatambo, envasada, idmuestraextraida, idmuestrafueracondicion, profundidad, idaguatratada, idestadodeconservacion, het22, het35, het37, cloro, conductividad, ph, ecoli, sulfitoreductores, enterococos, estreptococos, marca, muestraoficial, precinto, paqmacro, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, alcalinidad,refrendacion_tambo FROM analisisdeagua where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.IDTIPOPOZO = CType(unaFila.Item(3), Integer)
                    a.ANTIGUEDAD = CType(unaFila.Item(4), Double)
                    a.DISTANCIAPOZONEGRO = CType(unaFila.Item(5), Double)
                    a.DISTANCIATAMBO = CType(unaFila.Item(6), Double)
                    a.ENVASADA = CType(unaFila.Item(7), Integer)
                    a.IDMUESTRAEXTRAIDA = CType(unaFila.Item(8), Integer)
                    a.IDMUESTRAFUERACONDICION = CType(unaFila.Item(9), Integer)
                    a.PROFUNDIDAD = CType(unaFila.Item(10), Integer)
                    a.IDAGUATRATADA = CType(unaFila.Item(11), Integer)
                    a.IDESTADODECONSERVACION = CType(unaFila.Item(12), Integer)
                    a.HET22 = CType(unaFila.Item(13), Integer)
                    a.HET35 = CType(unaFila.Item(14), Integer)
                    a.HET37 = CType(unaFila.Item(15), Integer)
                    a.CLORO = CType(unaFila.Item(16), Integer)
                    a.CONDUCTIVIDAD = CType(unaFila.Item(17), Integer)
                    a.PH = CType(unaFila.Item(18), Integer)
                    a.ECOLI = CType(unaFila.Item(19), Integer)
                    a.SULFITOREDUCTORES = CType(unaFila.Item(20), Integer)
                    a.ENTEROCOCOS = CType(unaFila.Item(21), Integer)
                    a.ESTREPTOCOCOS = CType(unaFila.Item(22), Integer)
                    a.MARCA = CType(unaFila.Item(23), Integer)
                    a.MUESTRAOFICIAL = CType(unaFila.Item(24), Integer)
                    a.PRECINTO = CType(unaFila.Item(25), String)
                    a.PAQMACRO = CType(unaFila.Item(26), Integer)
                    a.CA = CType(unaFila.Item(27), Integer)
                    a.MG = CType(unaFila.Item(28), Integer)
                    a.NA = CType(unaFila.Item(29), Integer)
                    a.FE = CType(unaFila.Item(30), Integer)
                    a.K = CType(unaFila.Item(31), Integer)
                    a.AL = CType(unaFila.Item(32), Integer)
                    a.CD = CType(unaFila.Item(33), Integer)
                    a.CR = CType(unaFila.Item(34), Integer)
                    a.CU = CType(unaFila.Item(35), Integer)
                    a.PB = CType(unaFila.Item(36), Integer)
                    a.MN = CType(unaFila.Item(37), Integer)
                    a.FEM = CType(unaFila.Item(38), Integer)
                    a.ZN = CType(unaFila.Item(39), Integer)
                    a.SE = CType(unaFila.Item(40), Integer)
                    a.ALCALINIDAD = CType(unaFila.Item(41), Integer)
                    a.REFRENDACION_TAMBO = CType(unaFila.Item(42), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
