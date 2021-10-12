Public Class pAgua2
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAgua2 = CType(o, dAgua2)
        Dim sql As String = "INSERT INTO analisisdeagua2 (id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, coliformestotales, coliformesfecales, idaspecto, idolor, idcolor, ph, idmateriaorganica, conductividad, iddureza, nitrato, nitrito, fechaprocesamiento, heterotroficos, turbiedad, nitratotiras, nitritotiras, dureza, volumendesiembra, volumendesiembra2, tecnica, heterotroficos37, heterotroficos35, clorolibre, clororesidual, pseudomonasaeruginosa, pseudomonaspp, endo35, mfc44_5, centrimide37, mhpc, aguadedilucion, ecoli, sulfitoreductores, enterococos, estreptococos, lotenitrato, lotenitrito, lotedureza, operador, medios, marca) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.FECHAENTRADA & "','" & obj.FECHAEMISION & "','" & obj.IDMUESTRA & "', '" & obj.OBSERVACIONES & "', " & obj.COLIFORMESTOTALES & "," & obj.COLIFORMESFECALES & "," & obj.IDASPECTO & "," & obj.IDOLOR & "," & obj.IDCOLOR & "," & obj.PH & "," & obj.IDMATERIAORGANICA & ", " & obj.CONDUCTIVIDAD & ", " & obj.IDDUREZA & ", '" & obj.NITRATO & "','" & obj.NITRITO & "', '" & obj.FECHAPROCESAMIENTO & "', " & obj.HETEROTROFICOS & ", " & obj.TURBIEDAD & ", " & obj.NITRATOTIRAS & "," & obj.NITRITOTIRAS & ", '" & obj.DUREZA & "', " & obj.VOLUMENDESIEMBRA & "," & obj.VOLUMENDESIEMBRA2 & ", " & obj.TECNICA & "," & obj.HETEROTROFICOS37 & ", " & obj.HETEROTROFICOS35 & ", " & obj.CLOROLIBRE & ", " & obj.CLORORESIDUAL & ", " & obj.PSEUDOMONASAERUGINOSA & ", " & obj.PSEUDOMONASPP & ",'" & obj.ENDO35 & "', '" & obj.MFC44_5 & "', '" & obj.CENTRIMIDE37 & "', '" & obj.MHPC & "', '" & obj.AGUADEDILUCION & "', " & obj.ECOLI & "," & obj.SULFITOREDUCTORES & "," & obj.ENTEROCOCOS & "," & obj.ESTREPTOCOCOS & ",'" & obj.LOTENITRATO & "','" & obj.LOTENITRITO & "','" & obj.LOTEDUREZA & "'," & obj.OPERADOR & ", " & obj.MEDIOS & "," & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisisdeagua2', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAgua2 = CType(o, dAgua2)
        Dim sql As String = "UPDATE analisisdeagua2 SET ficha = " & obj.FICHA & ",  fechaentrada ='" & obj.FECHAENTRADA & "',fechaemision ='" & obj.FECHAEMISION & "', idmuestra ='" & obj.IDMUESTRA & "',observaciones ='" & obj.OBSERVACIONES & "',coliformestotales =" & obj.COLIFORMESTOTALES & ",coliformesfecales =" & obj.COLIFORMESFECALES & ",idaspecto =" & obj.IDASPECTO & ",idolor =" & obj.IDOLOR & ",idcolor =" & obj.IDCOLOR & ", ph =" & obj.PH & ", idmateriaorganica=" & obj.IDMATERIAORGANICA & ", conductividad=" & obj.CONDUCTIVIDAD & ", iddureza=" & obj.IDDUREZA & ", nitrato='" & obj.NITRATO & "', nitrito='" & obj.NITRITO & "', fechaprocesamiento='" & obj.FECHAPROCESAMIENTO & "', heterotroficos=" & obj.HETEROTROFICOS & ", turbiedad=" & obj.TURBIEDAD & ", nitratotiras=" & obj.NITRATOTIRAS & ",nitritotiras=" & obj.NITRITOTIRAS & ", dureza='" & obj.DUREZA & "', volumendesiembra=" & obj.VOLUMENDESIEMBRA & ",volumendesiembra2=" & obj.VOLUMENDESIEMBRA2 & ", tecnica=" & obj.TECNICA & ", heterotroficos37=" & obj.HETEROTROFICOS37 & ", heterotroficos35=" & obj.HETEROTROFICOS35 & ", clorolibre=" & obj.CLOROLIBRE & ", clororesidual=" & obj.CLORORESIDUAL & ", pseudomonasaeruginosa=" & obj.PSEUDOMONASAERUGINOSA & ", pseudomonaspp=" & obj.PSEUDOMONASPP & ",endo35='" & obj.ENDO35 & "', mfc44_5='" & obj.MFC44_5 & "', centrimide37='" & obj.CENTRIMIDE37 & "', mhpc='" & obj.MHPC & "', aguadedilucion='" & obj.AGUADEDILUCION & "',ecoli=" & obj.ECOLI & ",sulfitoreductores=" & obj.SULFITOREDUCTORES & ", enterococos=" & obj.ENTEROCOCOS & ", estreptococos=" & obj.ESTREPTOCOCOS & ", lotenitrato='" & obj.LOTENITRATO & "',lotenitrito='" & obj.LOTENITRITO & "',lotedureza='" & obj.LOTEDUREZA & "', operador=" & obj.OPERADOR & ", medios=" & obj.MEDIOS & ",marca=" & obj.MARCA & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisisdeagua2', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAgua2 = CType(o, dAgua2)
        Dim sql As String = "UPDATE analisisdeagua2 SET fechaemision ='" & obj.FECHAEMISION & "', marca=" & obj.MARCA & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisisdeagua2', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarficha(ByVal o As Object) As Boolean
        Dim obj As dAgua2 = CType(o, dAgua2)
        Dim sql As String = "UPDATE analisisdeagua2 SET marca = 0 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAgua2 = CType(o, dAgua2)
        Dim sql As String = "DELETE FROM analisisdeagua2 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisisdeagua2', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAgua2
        Dim obj As dAgua2 = CType(o, dAgua2)
        Dim a As New dAgua2
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, coliformestotales, coliformesfecales, idaspecto, idolor, idcolor, ph, idmateriaorganica, conductividad, iddureza, nitrato, nitrito, fechaprocesamiento, heterotroficos, turbiedad, nitratotiras, nitritotiras, dureza, volumendesiembra, volumendesiembra2, tecnica, heterotroficos37, heterotroficos35, clorolibre, clororesidual, pseudomonasaeruginosa, pseudomonaspp, endo35, mfc44_5, centrimide37, mhpc, aguadedilucion, ecoli, sulfitoreductores, enterococos, estreptococos, ifnull(lotenitrato,''), ifnull(lotenitrito,''), ifnull(lotedureza,''), operador, medios, marca FROM analisisdeagua2 WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                a.ID = CType(unaFila.Item(0), Long)
                a.ficha = CType(unaFila.Item(1), Long)
                a.FECHAENTRADA = CType(unaFila.Item(2), String)
                a.FECHAEMISION = CType(unaFila.Item(3), String)
                a.IDMUESTRA = CType(unaFila.Item(4), String)
                a.OBSERVACIONES = CType(unaFila.Item(5), String)
                a.COLIFORMESTOTALES = CType(unaFila.Item(6), Integer)
                a.COLIFORMESFECALES = CType(unaFila.Item(7), Integer)
                a.IDASPECTO = CType(unaFila.Item(8), Integer)
                a.IDOLOR = CType(unaFila.Item(9), Integer)
                a.IDCOLOR = CType(unaFila.Item(10), Integer)
                a.PH = CType(unaFila.Item(11), Double)
                a.IDMATERIAORGANICA = CType(unaFila.Item(12), Integer)
                a.CONDUCTIVIDAD = CType(unaFila.Item(13), Double)
                a.IDDUREZA = CType(unaFila.Item(14), Integer)
                a.NITRATO = CType(unaFila.Item(15), String)
                a.NITRITO = CType(unaFila.Item(16), String)
                a.FECHAPROCESAMIENTO = CType(unaFila.Item(17), String)
                a.HETEROTROFICOS = CType(unaFila.Item(18), Double)
                a.TURBIEDAD = CType(unaFila.Item(19), Double)
                a.NITRATOTIRAS = CType(unaFila.Item(20), Integer)
                a.NITRITOTIRAS = CType(unaFila.Item(21), Integer)
                a.DUREZA = CType(unaFila.Item(22), String)
                a.VOLUMENDESIEMBRA = CType(unaFila.Item(23), Integer)
                a.VOLUMENDESIEMBRA2 = CType(unaFila.Item(24), Integer)
                a.TECNICA = CType(unaFila.Item(25), Integer)
                a.HETEROTROFICOS37 = CType(unaFila.Item(26), Double)
                a.HETEROTROFICOS35 = CType(unaFila.Item(27), Double)
                a.CLOROLIBRE = CType(unaFila.Item(28), Double)
                a.CLORORESIDUAL = CType(unaFila.Item(29), Double)
                a.PSEUDOMONASAERUGINOSA = CType(unaFila.Item(30), Integer)
                a.PSEUDOMONASPP = CType(unaFila.Item(31), Integer)
                a.ENDO35 = CType(unaFila.Item(32), String)
                a.MFC44_5 = CType(unaFila.Item(33), String)
                a.CENTRIMIDE37 = CType(unaFila.Item(34), String)
                a.MHPC = CType(unaFila.Item(35), String)
                a.AGUADEDILUCION = CType(unaFila.Item(36), String)
                a.ECOLI = CType(unaFila.Item(37), Integer)
                a.SULFITOREDUCTORES = CType(unaFila.Item(38), Integer)
                a.ENTEROCOCOS = CType(unaFila.Item(39), Integer)
                a.ESTREPTOCOCOS = CType(unaFila.Item(40), Integer)
                a.LOTENITRATO = CType(unaFila.Item(41), String)
                a.LOTENITRITO = CType(unaFila.Item(42), String)
                a.LOTEDUREZA = CType(unaFila.Item(43), String)
                a.OPERADOR = CType(unaFila.Item(44), Integer)
                a.MEDIOS = CType(unaFila.Item(45), Integer)
                a.MARCA = CType(unaFila.Item(46), Integer)
                Return a
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, coliformestotales, coliformesfecales, idaspecto, idolor, idcolor, ph, idmateriaorganica, conductividad, iddureza,  nitrato, nitrito, fechaprocesamiento, heterotroficos, turbiedad, nitratotiras, nitritotiras, dureza, volumendesiembra, volumendesiembra2, tecnica, heterotroficos37, heterotroficos35, clorolibre, clororesidual, pseudomonasaeruginosa, pseudomonaspp, endo35, mfc44_5, centrimide37, mhpc, aguadedilucion, ecoli, sulfitoreductores, enterococos, estreptococos, ifnull(lotenitrato,''), ifnull(lotenitrito,''), ifnull(lotedureza,''), operador, medios, marca  FROM analisisdeagua2 WHERE marca = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua2
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.FECHAEMISION = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.OBSERVACIONES = CType(unaFila.Item(5), String)
                    a.COLIFORMESTOTALES = CType(unaFila.Item(6), Integer)
                    a.COLIFORMESFECALES = CType(unaFila.Item(7), Integer)
                    a.IDASPECTO = CType(unaFila.Item(8), Integer)
                    a.IDOLOR = CType(unaFila.Item(9), Integer)
                    a.IDCOLOR = CType(unaFila.Item(10), Integer)
                    a.PH = CType(unaFila.Item(11), Double)
                    a.IDMATERIAORGANICA = CType(unaFila.Item(12), Integer)
                    a.CONDUCTIVIDAD = CType(unaFila.Item(13), Double)
                    a.IDDUREZA = CType(unaFila.Item(14), Integer)
                    a.NITRATO = CType(unaFila.Item(15), String)
                    a.NITRITO = CType(unaFila.Item(16), String)
                    a.FECHAPROCESAMIENTO = CType(unaFila.Item(17), String)
                    a.HETEROTROFICOS = CType(unaFila.Item(18), Double)
                    a.TURBIEDAD = CType(unaFila.Item(19), Double)
                    a.NITRATOTIRAS = CType(unaFila.Item(20), Integer)
                    a.NITRITOTIRAS = CType(unaFila.Item(21), Integer)
                    a.DUREZA = CType(unaFila.Item(22), String)
                    a.VOLUMENDESIEMBRA = CType(unaFila.Item(23), Integer)
                    a.VOLUMENDESIEMBRA2 = CType(unaFila.Item(24), Integer)
                    a.TECNICA = CType(unaFila.Item(25), Integer)
                    a.HETEROTROFICOS37 = CType(unaFila.Item(26), Double)
                    a.HETEROTROFICOS35 = CType(unaFila.Item(27), Double)
                    a.CLOROLIBRE = CType(unaFila.Item(28), Double)
                    a.CLORORESIDUAL = CType(unaFila.Item(29), Double)
                    a.PSEUDOMONASAERUGINOSA = CType(unaFila.Item(30), Integer)
                    a.PSEUDOMONASPP = CType(unaFila.Item(31), Integer)
                    a.ENDO35 = CType(unaFila.Item(32), String)
                    a.MFC44_5 = CType(unaFila.Item(33), String)
                    a.CENTRIMIDE37 = CType(unaFila.Item(34), String)
                    a.MHPC = CType(unaFila.Item(35), String)
                    a.AGUADEDILUCION = CType(unaFila.Item(36), String)
                    a.ECOLI = CType(unaFila.Item(37), Integer)
                    a.SULFITOREDUCTORES = CType(unaFila.Item(38), Integer)
                    a.ENTEROCOCOS = CType(unaFila.Item(39), Integer)
                    a.ESTREPTOCOCOS = CType(unaFila.Item(40), Integer)
                    a.LOTENITRATO = CType(unaFila.Item(41), String)
                    a.LOTENITRITO = CType(unaFila.Item(42), String)
                    a.LOTEDUREZA = CType(unaFila.Item(43), String)
                    a.OPERADOR = CType(unaFila.Item(44), Integer)
                    a.MEDIOS = CType(unaFila.Item(45), Integer)
                    a.MARCA = CType(unaFila.Item(46), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM analisisdeagua2 WHERE marca = 0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua2
                    a.ficha = CType(unaFila.Item(0), Long)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, coliformestotales, coliformesfecales, idaspecto, idolor, idcolor, ph, idmateriaorganica, conductividad, iddureza,  nitrato, nitrito, fechaprocesamiento, heterotroficos, turbiedad, nitratotiras, nitritotiras, dureza, volumendesiembra, volumendesiembra2, tecnica, heterotroficos37, heterotroficos35, clorolibre, clororesidual, pseudomonasaeruginosa, pseudomonaspp, endo35, mfc44_5, centrimide37, mhpc, aguadedilucion, ecoli, sulfitoreductores, enterococos, estreptococos, ifnull(lotenitrato,''), ifnull(lotenitrito,''), ifnull(lotedureza,''), operador, medios, marca  FROM analisisdeagua2 where marca = 0 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua2
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.FECHAEMISION = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.OBSERVACIONES = CType(unaFila.Item(5), String)
                    a.COLIFORMESTOTALES = CType(unaFila.Item(6), Integer)
                    a.COLIFORMESFECALES = CType(unaFila.Item(7), Integer)
                    a.IDASPECTO = CType(unaFila.Item(8), Integer)
                    a.IDOLOR = CType(unaFila.Item(9), Integer)
                    a.IDCOLOR = CType(unaFila.Item(10), Integer)
                    a.PH = CType(unaFila.Item(11), Double)
                    a.IDMATERIAORGANICA = CType(unaFila.Item(12), Integer)
                    a.CONDUCTIVIDAD = CType(unaFila.Item(13), Double)
                    a.IDDUREZA = CType(unaFila.Item(14), Integer)
                    a.NITRATO = CType(unaFila.Item(15), String)
                    a.NITRITO = CType(unaFila.Item(16), String)
                    a.FECHAPROCESAMIENTO = CType(unaFila.Item(17), String)
                    a.HETEROTROFICOS = CType(unaFila.Item(18), Double)
                    a.TURBIEDAD = CType(unaFila.Item(19), Double)
                    a.NITRATOTIRAS = CType(unaFila.Item(20), Integer)
                    a.NITRITOTIRAS = CType(unaFila.Item(21), Integer)
                    a.DUREZA = CType(unaFila.Item(22), String)
                    a.VOLUMENDESIEMBRA = CType(unaFila.Item(23), Integer)
                    a.VOLUMENDESIEMBRA2 = CType(unaFila.Item(24), Integer)
                    a.TECNICA = CType(unaFila.Item(25), Integer)
                    a.HETEROTROFICOS37 = CType(unaFila.Item(26), Double)
                    a.HETEROTROFICOS35 = CType(unaFila.Item(27), Double)
                    a.CLOROLIBRE = CType(unaFila.Item(28), Double)
                    a.CLORORESIDUAL = CType(unaFila.Item(29), Double)
                    a.PSEUDOMONASAERUGINOSA = CType(unaFila.Item(30), Integer)
                    a.PSEUDOMONASPP = CType(unaFila.Item(31), Integer)
                    a.ENDO35 = CType(unaFila.Item(32), String)
                    a.MFC44_5 = CType(unaFila.Item(33), String)
                    a.CENTRIMIDE37 = CType(unaFila.Item(34), String)
                    a.MHPC = CType(unaFila.Item(35), String)
                    a.AGUADEDILUCION = CType(unaFila.Item(36), String)
                    a.ECOLI = CType(unaFila.Item(37), Integer)
                    a.SULFITOREDUCTORES = CType(unaFila.Item(38), Integer)
                    a.ENTEROCOCOS = CType(unaFila.Item(39), Integer)
                    a.ESTREPTOCOCOS = CType(unaFila.Item(40), Integer)
                    a.LOTENITRATO = CType(unaFila.Item(41), String)
                    a.LOTENITRITO = CType(unaFila.Item(42), String)
                    a.LOTEDUREZA = CType(unaFila.Item(43), String)
                    a.OPERADOR = CType(unaFila.Item(44), Integer)
                    a.MEDIOS = CType(unaFila.Item(45), Integer)
                    a.MARCA = CType(unaFila.Item(46), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporid2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, coliformestotales, coliformesfecales, idaspecto, idolor, idcolor, ph, idmateriaorganica, conductividad, iddureza,  nitrato, nitrito, fechaprocesamiento, heterotroficos, turbiedad, nitratotiras, nitritotiras, dureza, volumendesiembra, volumendesiembra2, tecnica, heterotroficos37, heterotroficos35, clorolibre, clororesidual, pseudomonasaeruginosa, pseudomonaspp, endo35, mfc44_5, centrimide37, mhpc, aguadedilucion, ecoli, sulfitoreductores, enterococos, estreptococos, ifnull(lotenitrato,''), ifnull(lotenitrito,''), ifnull(lotedureza,''), operador, medios, marca  FROM analisisdeagua2 where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua2
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.FECHAEMISION = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.OBSERVACIONES = CType(unaFila.Item(5), String)
                    a.COLIFORMESTOTALES = CType(unaFila.Item(6), Integer)
                    a.COLIFORMESFECALES = CType(unaFila.Item(7), Integer)
                    a.IDASPECTO = CType(unaFila.Item(8), Integer)
                    a.IDOLOR = CType(unaFila.Item(9), Integer)
                    a.IDCOLOR = CType(unaFila.Item(10), Integer)
                    a.PH = CType(unaFila.Item(11), Double)
                    a.IDMATERIAORGANICA = CType(unaFila.Item(12), Integer)
                    a.CONDUCTIVIDAD = CType(unaFila.Item(13), Double)
                    a.IDDUREZA = CType(unaFila.Item(14), Integer)
                    a.NITRATO = CType(unaFila.Item(15), String)
                    a.NITRITO = CType(unaFila.Item(16), String)
                    a.FECHAPROCESAMIENTO = CType(unaFila.Item(17), String)
                    a.HETEROTROFICOS = CType(unaFila.Item(18), Double)
                    a.TURBIEDAD = CType(unaFila.Item(19), Double)
                    a.NITRATOTIRAS = CType(unaFila.Item(20), Integer)
                    a.NITRITOTIRAS = CType(unaFila.Item(21), Integer)
                    a.DUREZA = CType(unaFila.Item(22), String)
                    a.VOLUMENDESIEMBRA = CType(unaFila.Item(23), Integer)
                    a.VOLUMENDESIEMBRA2 = CType(unaFila.Item(24), Integer)
                    a.TECNICA = CType(unaFila.Item(25), Integer)
                    a.HETEROTROFICOS37 = CType(unaFila.Item(26), Double)
                    a.HETEROTROFICOS35 = CType(unaFila.Item(27), Double)
                    a.CLOROLIBRE = CType(unaFila.Item(28), Double)
                    a.CLORORESIDUAL = CType(unaFila.Item(29), Double)
                    a.PSEUDOMONASAERUGINOSA = CType(unaFila.Item(30), Integer)
                    a.PSEUDOMONASPP = CType(unaFila.Item(31), Integer)
                    a.ENDO35 = CType(unaFila.Item(32), String)
                    a.MFC44_5 = CType(unaFila.Item(33), String)
                    a.CENTRIMIDE37 = CType(unaFila.Item(34), String)
                    a.MHPC = CType(unaFila.Item(35), String)
                    a.AGUADEDILUCION = CType(unaFila.Item(36), String)
                    a.ECOLI = CType(unaFila.Item(37), Integer)
                    a.SULFITOREDUCTORES = CType(unaFila.Item(38), Integer)
                    a.ENTEROCOCOS = CType(unaFila.Item(39), Integer)
                    a.ESTREPTOCOCOS = CType(unaFila.Item(40), Integer)
                    a.LOTENITRATO = CType(unaFila.Item(41), String)
                    a.LOTENITRITO = CType(unaFila.Item(42), String)
                    a.LOTEDUREZA = CType(unaFila.Item(43), String)
                    a.OPERADOR = CType(unaFila.Item(44), Integer)
                    a.MEDIOS = CType(unaFila.Item(45), Integer)
                    a.MARCA = CType(unaFila.Item(46), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, coliformestotales, coliformesfecales, idaspecto, idolor, idcolor, ph, idmateriaorganica, conductividad, iddureza,  nitrato, nitrito, fechaprocesamiento, heterotroficos, turbiedad, nitratotiras, nitritotiras, dureza, volumendesiembra, volumendesiembra2, tecnica, heterotroficos37, heterotroficos35, clorolibre, clororesidual, pseudomonasaeruginosa, pseudomonaspp, endo35, mfc44_5, centrimide37, mhpc, aguadedilucion, ecoli, sulfitoreductores, enterococos, estreptococos, ifnull(lotenitrato,''), ifnull(lotenitrito,''), ifnull(lotedureza,''), operador, medios, marca  FROM analisisdeagua2 where marca = 0 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua2
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.FECHAEMISION = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.OBSERVACIONES = CType(unaFila.Item(5), String)
                    a.COLIFORMESTOTALES = CType(unaFila.Item(6), Integer)
                    a.COLIFORMESFECALES = CType(unaFila.Item(7), Integer)
                    a.IDASPECTO = CType(unaFila.Item(8), Integer)
                    a.IDOLOR = CType(unaFila.Item(9), Integer)
                    a.IDCOLOR = CType(unaFila.Item(10), Integer)
                    a.PH = CType(unaFila.Item(11), Double)
                    a.IDMATERIAORGANICA = CType(unaFila.Item(12), Integer)
                    a.CONDUCTIVIDAD = CType(unaFila.Item(13), Double)
                    a.IDDUREZA = CType(unaFila.Item(14), Integer)
                    a.NITRATO = CType(unaFila.Item(15), String)
                    a.NITRITO = CType(unaFila.Item(16), String)
                    a.FECHAPROCESAMIENTO = CType(unaFila.Item(17), String)
                    a.HETEROTROFICOS = CType(unaFila.Item(18), Double)
                    a.TURBIEDAD = CType(unaFila.Item(19), Double)
                    a.NITRATOTIRAS = CType(unaFila.Item(20), Integer)
                    a.NITRITOTIRAS = CType(unaFila.Item(21), Integer)
                    a.DUREZA = CType(unaFila.Item(22), String)
                    a.VOLUMENDESIEMBRA = CType(unaFila.Item(23), Integer)
                    a.VOLUMENDESIEMBRA2 = CType(unaFila.Item(24), Integer)
                    a.TECNICA = CType(unaFila.Item(25), Integer)
                    a.HETEROTROFICOS37 = CType(unaFila.Item(26), Double)
                    a.HETEROTROFICOS35 = CType(unaFila.Item(27), Double)
                    a.CLOROLIBRE = CType(unaFila.Item(28), Double)
                    a.CLORORESIDUAL = CType(unaFila.Item(29), Double)
                    a.PSEUDOMONASAERUGINOSA = CType(unaFila.Item(30), Integer)
                    a.PSEUDOMONASPP = CType(unaFila.Item(31), Integer)
                    a.ENDO35 = CType(unaFila.Item(32), String)
                    a.MFC44_5 = CType(unaFila.Item(33), String)
                    a.CENTRIMIDE37 = CType(unaFila.Item(34), String)
                    a.MHPC = CType(unaFila.Item(35), String)
                    a.AGUADEDILUCION = CType(unaFila.Item(36), String)
                    a.ECOLI = CType(unaFila.Item(37), Integer)
                    a.SULFITOREDUCTORES = CType(unaFila.Item(38), Integer)
                    a.ENTEROCOCOS = CType(unaFila.Item(39), Integer)
                    a.ESTREPTOCOCOS = CType(unaFila.Item(40), Integer)
                    a.LOTENITRATO = CType(unaFila.Item(41), String)
                    a.LOTENITRITO = CType(unaFila.Item(42), String)
                    a.LOTEDUREZA = CType(unaFila.Item(43), String)
                    a.OPERADOR = CType(unaFila.Item(44), Integer)
                    a.MEDIOS = CType(unaFila.Item(45), Integer)
                    a.MARCA = CType(unaFila.Item(46), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, coliformestotales, coliformesfecales, idaspecto, idolor, idcolor, ph, idmateriaorganica, conductividad, iddureza,  nitrato, nitrito, fechaprocesamiento, heterotroficos, turbiedad, nitratotiras, nitritotiras, dureza, volumendesiembra, volumendesiembra2, tecnica, heterotroficos37, heterotroficos35, clorolibre, clororesidual, pseudomonasaeruginosa, pseudomonaspp, endo35, mfc44_5, centrimide37, mhpc, aguadedilucion, ecoli, sulfitoreductores, enterococos, estreptococos, ifnull(lotenitrato,''), ifnull(lotenitrito,''), ifnull(lotedureza,''), operador, medios, marca  FROM analisisdeagua2 where marca = 1 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua2
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.FECHAEMISION = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.OBSERVACIONES = CType(unaFila.Item(5), String)
                    a.COLIFORMESTOTALES = CType(unaFila.Item(6), Integer)
                    a.COLIFORMESFECALES = CType(unaFila.Item(7), Integer)
                    a.IDASPECTO = CType(unaFila.Item(8), Integer)
                    a.IDOLOR = CType(unaFila.Item(9), Integer)
                    a.IDCOLOR = CType(unaFila.Item(10), Integer)
                    a.PH = CType(unaFila.Item(11), Double)
                    a.IDMATERIAORGANICA = CType(unaFila.Item(12), Integer)
                    a.CONDUCTIVIDAD = CType(unaFila.Item(13), Double)
                    a.IDDUREZA = CType(unaFila.Item(14), Integer)
                    a.NITRATO = CType(unaFila.Item(15), String)
                    a.NITRITO = CType(unaFila.Item(16), String)
                    a.FECHAPROCESAMIENTO = CType(unaFila.Item(17), String)
                    a.HETEROTROFICOS = CType(unaFila.Item(18), Double)
                    a.TURBIEDAD = CType(unaFila.Item(19), Double)
                    a.NITRATOTIRAS = CType(unaFila.Item(20), Integer)
                    a.NITRITOTIRAS = CType(unaFila.Item(21), Integer)
                    a.DUREZA = CType(unaFila.Item(22), String)
                    a.VOLUMENDESIEMBRA = CType(unaFila.Item(23), Integer)
                    a.VOLUMENDESIEMBRA2 = CType(unaFila.Item(24), Integer)
                    a.TECNICA = CType(unaFila.Item(25), Integer)
                    a.HETEROTROFICOS37 = CType(unaFila.Item(26), Double)
                    a.HETEROTROFICOS35 = CType(unaFila.Item(27), Double)
                    a.CLOROLIBRE = CType(unaFila.Item(28), Double)
                    a.CLORORESIDUAL = CType(unaFila.Item(29), Double)
                    a.PSEUDOMONASAERUGINOSA = CType(unaFila.Item(30), Integer)
                    a.PSEUDOMONASPP = CType(unaFila.Item(31), Integer)
                    a.ENDO35 = CType(unaFila.Item(32), String)
                    a.MFC44_5 = CType(unaFila.Item(33), String)
                    a.CENTRIMIDE37 = CType(unaFila.Item(34), String)
                    a.MHPC = CType(unaFila.Item(35), String)
                    a.AGUADEDILUCION = CType(unaFila.Item(36), String)
                    a.ECOLI = CType(unaFila.Item(37), Integer)
                    a.SULFITOREDUCTORES = CType(unaFila.Item(38), Integer)
                    a.ENTEROCOCOS = CType(unaFila.Item(39), Integer)
                    a.ESTREPTOCOCOS = CType(unaFila.Item(40), Integer)
                    a.LOTENITRATO = CType(unaFila.Item(41), String)
                    a.LOTENITRITO = CType(unaFila.Item(42), String)
                    a.LOTEDUREZA = CType(unaFila.Item(43), String)
                    a.OPERADOR = CType(unaFila.Item(44), Integer)
                    a.MEDIOS = CType(unaFila.Item(45), Integer)
                    a.MARCA = CType(unaFila.Item(46), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, coliformestotales, coliformesfecales, idaspecto, idolor, idcolor, ph, idmateriaorganica, conductividad, iddureza,  nitrato, nitrito ,fechaprocesamiento, heterotroficos, turbiedad, nitratotiras, nitritotiras, dureza, volumendesiembra, volumendesiembra2, tecnica, heterotroficos37, heterotroficos35, clorolibre, clororesidual, pseudomonasaeruginosa, pseudomonaspp, endo35, mfc44_5, centrimide37, mhpc, aguadedilucion, ecoli, sulfitoreductores, enterococos, estreptococos, ifnull(lotenitrato,''), ifnull(lotenitrito,''), ifnull(lotedureza,''), operador, medios, marca  FROM analisisdeagua2 where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua2
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.FECHAEMISION = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.OBSERVACIONES = CType(unaFila.Item(5), String)
                    a.COLIFORMESTOTALES = CType(unaFila.Item(6), Integer)
                    a.COLIFORMESFECALES = CType(unaFila.Item(7), Integer)
                    a.IDASPECTO = CType(unaFila.Item(8), Integer)
                    a.IDOLOR = CType(unaFila.Item(9), Integer)
                    a.IDCOLOR = CType(unaFila.Item(10), Integer)
                    a.PH = CType(unaFila.Item(11), Double)
                    a.IDMATERIAORGANICA = CType(unaFila.Item(12), Integer)
                    a.CONDUCTIVIDAD = CType(unaFila.Item(13), Double)
                    a.IDDUREZA = CType(unaFila.Item(14), Integer)
                    a.NITRATO = CType(unaFila.Item(15), String)
                    a.NITRITO = CType(unaFila.Item(16), String)
                    a.FECHAPROCESAMIENTO = CType(unaFila.Item(17), String)
                    a.HETEROTROFICOS = CType(unaFila.Item(18), Double)
                    a.TURBIEDAD = CType(unaFila.Item(19), Double)
                    a.NITRATOTIRAS = CType(unaFila.Item(20), Integer)
                    a.NITRITOTIRAS = CType(unaFila.Item(21), Integer)
                    a.DUREZA = CType(unaFila.Item(22), String)
                    a.VOLUMENDESIEMBRA = CType(unaFila.Item(23), Integer)
                    a.VOLUMENDESIEMBRA2 = CType(unaFila.Item(24), Integer)
                    a.TECNICA = CType(unaFila.Item(25), Integer)
                    a.HETEROTROFICOS37 = CType(unaFila.Item(26), Double)
                    a.HETEROTROFICOS35 = CType(unaFila.Item(27), Double)
                    a.CLOROLIBRE = CType(unaFila.Item(28), Double)
                    a.CLORORESIDUAL = CType(unaFila.Item(29), Double)
                    a.PSEUDOMONASAERUGINOSA = CType(unaFila.Item(30), Integer)
                    a.PSEUDOMONASPP = CType(unaFila.Item(31), Integer)
                    a.ENDO35 = CType(unaFila.Item(32), String)
                    a.MFC44_5 = CType(unaFila.Item(33), String)
                    a.CENTRIMIDE37 = CType(unaFila.Item(34), String)
                    a.MHPC = CType(unaFila.Item(35), String)
                    a.AGUADEDILUCION = CType(unaFila.Item(36), String)
                    a.ECOLI = CType(unaFila.Item(37), Integer)
                    a.SULFITOREDUCTORES = CType(unaFila.Item(38), Integer)
                    a.ENTEROCOCOS = CType(unaFila.Item(39), Integer)
                    a.ESTREPTOCOCOS = CType(unaFila.Item(40), Integer)
                    a.LOTENITRATO = CType(unaFila.Item(41), String)
                    a.LOTENITRITO = CType(unaFila.Item(42), String)
                    a.LOTEDUREZA = CType(unaFila.Item(43), String)
                    a.OPERADOR = CType(unaFila.Item(44), Integer)
                    a.MEDIOS = CType(unaFila.Item(45), Integer)
                    a.MARCA = CType(unaFila.Item(46), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
