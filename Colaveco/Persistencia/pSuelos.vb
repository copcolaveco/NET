Public Class pSuelos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSuelos = CType(o, dSuelos)
        Dim sql As String = "INSERT INTO suelos (id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, fosforobray, fosforocitrico, nitratos, phagua, phkci, potasioint, sulfatos, nitrogenovegetal, carbonoorganico, materiaorganica, pmn, calcio, magnesio, sodio, acideztitulable, cic, sb, zinc, operador, marca) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.FECHAINGRESO & "','" & obj.FECHAPROCESO & "','" & obj.MUESTRA & "','" & obj.DETALLEMUESTRA & "'," & obj.FOSFOROBRAY & ",  " & obj.FOSFOROCITRICO & ", " & obj.NITRATOS & "," & obj.PHAGUA & ", " & obj.PHKCI & ", " & obj.POTASIOINT & ", " & obj.SULFATOS & ", " & obj.NITROGENOVEGETAL & "," & obj.CARBONOORGANICO & "," & obj.MATERIAORGANICA & ", " & obj.PMN & "," & obj.CALCIO & "," & obj.MAGNESIO & "," & obj.SODIO & "," & obj.ACIDEZTITULABLE & "," & obj.CIC & "," & obj.SB & "," & obj.ZINC & ",  " & obj.OPERADOR & "," & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'suelos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSuelos = CType(o, dSuelos)
        Dim sql As String = "UPDATE suelos SET ficha=" & obj.FICHA & ", fechaingreso='" & obj.FECHAINGRESO & "', fechaproceso='" & obj.FECHAPROCESO & "', muestra='" & obj.MUESTRA & "', detallemuestra='" & obj.DETALLEMUESTRA & "', fosforobray=" & obj.FOSFOROBRAY & ",  fosforocitrico= " & obj.FOSFOROCITRICO & ", nitratos= " & obj.NITRATOS & ",phagua=" & obj.PHAGUA & ", phkci= " & obj.PHKCI & ", potasioint= " & obj.POTASIOINT & ", sulfatos= " & obj.SULFATOS & ", nitrogenovegetal= " & obj.NITROGENOVEGETAL & ", carbonoorganico=" & obj.CARBONOORGANICO & ", materiaorganica=" & obj.MATERIAORGANICA & ", pmn= " & obj.PMN & ",calcio= " & obj.CALCIO & ", magnesio= " & obj.MAGNESIO & ",sodio= " & obj.SODIO & ",acideztitulable= " & obj.ACIDEZTITULABLE & ",cic= " & obj.CIC & ",sb= " & obj.SB & ",zinc= " & obj.ZINC & ",operador= " & obj.OPERADOR & ", marca=" & obj.MARCA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'suelos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSuelos = CType(o, dSuelos)
        Dim sql As String = "UPDATE suelos SET marca=" & obj.MARCA & " WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'suelos', 'marcar', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarficha(ByVal o As Object) As Boolean
        Dim obj As dSuelos = CType(o, dSuelos)
        Dim sql As String = "UPDATE suelos SET marca = 0 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function

    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSuelos = CType(o, dSuelos)
        Dim sql As String = "DELETE FROM suelos WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'suelos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSuelos = CType(o, dSuelos)
        Dim sql As String = "DELETE FROM suelos WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'suelos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dSuelos
        Dim obj As dSuelos = CType(o, dSuelos)
        Dim s As New dSuelos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, fosforobray, fosforocitrico, nitratos, phagua, phkci, potasioint, sulfatos, nitrogenovegetal, carbonoorganico, materiaorganica, pmn, calcio, magnesio, sodio, acideztitulable, cic, sb, zinc, operador, marca FROM suelos WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Long)
                s.FICHA = CType(unaFila.Item(1), Long)
                s.FECHAINGRESO = CType(unaFila.Item(2), String)
                s.FECHAPROCESO = CType(unaFila.Item(3), String)
                s.MUESTRA = CType(unaFila.Item(4), String)
                s.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                s.FOSFOROBRAY = CType(unaFila.Item(6), Double)
                s.FOSFOROCITRICO = CType(unaFila.Item(7), Double)
                s.NITRATOS = CType(unaFila.Item(8), Double)
                s.PHAGUA = CType(unaFila.Item(9), Double)
                s.PHKCI = CType(unaFila.Item(10), Double)
                s.POTASIOINT = CType(unaFila.Item(11), Double)
                s.SULFATOS = CType(unaFila.Item(12), Double)
                s.NITROGENOVEGETAL = CType(unaFila.Item(13), Double)
                s.CARBONOORGANICO = CType(unaFila.Item(14), Double)
                s.MATERIAORGANICA = CType(unaFila.Item(15), Double)
                s.PMN = CType(unaFila.Item(16), Double)
                s.CALCIO = CType(unaFila.Item(17), Double)
                s.MAGNESIO = CType(unaFila.Item(18), Double)
                s.SODIO = CType(unaFila.Item(19), Double)
                s.ACIDEZTITULABLE = CType(unaFila.Item(20), Double)
                s.CIC = CType(unaFila.Item(21), Double)
                s.SB = CType(unaFila.Item(22), Double)
                s.ZINC = CType(unaFila.Item(23), Double)
                s.OPERADOR = CType(unaFila.Item(24), Integer)
                s.MARCA = CType(unaFila.Item(25), Integer)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfechaproceso(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, fosforobray, fosforocitrico, nitratos, phagua, phkci, potasioint, sulfatos, nitrogenovegetal, carbonoorganico, materiaorganica, pmn, calcio, magnesio, sodio, acideztitulable, cic, sb, zinc, operador, marca FROM suelos where ficha = " & texto & " LIMIT 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSuelos
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FICHA = CType(unaFila.Item(1), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(2), String)
                    s.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s.MUESTRA = CType(unaFila.Item(4), String)
                    s.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    s.FOSFOROBRAY = CType(unaFila.Item(6), Double)
                    s.FOSFOROCITRICO = CType(unaFila.Item(7), Double)
                    s.NITRATOS = CType(unaFila.Item(8), Double)
                    s.PHAGUA = CType(unaFila.Item(9), Double)
                    s.PHKCI = CType(unaFila.Item(10), Double)
                    s.POTASIOINT = CType(unaFila.Item(11), Double)
                    s.SULFATOS = CType(unaFila.Item(12), Double)
                    s.NITROGENOVEGETAL = CType(unaFila.Item(13), Double)
                    s.CARBONOORGANICO = CType(unaFila.Item(14), Double)
                    s.MATERIAORGANICA = CType(unaFila.Item(15), Double)
                    s.PMN = CType(unaFila.Item(16), Double)
                    s.CALCIO = CType(unaFila.Item(17), Double)
                    s.MAGNESIO = CType(unaFila.Item(18), Double)
                    s.SODIO = CType(unaFila.Item(19), Double)
                    s.ACIDEZTITULABLE = CType(unaFila.Item(20), Double)
                    s.CIC = CType(unaFila.Item(21), Double)
                    s.SB = CType(unaFila.Item(22), Double)
                    s.ZINC = CType(unaFila.Item(23), Double)
                    s.OPERADOR = CType(unaFila.Item(24), Integer)
                    s.MARCA = CType(unaFila.Item(25), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, fosforobray, fosforocitrico, nitratos, phagua, phkci, potasioint, sulfatos, nitrogenovegetal, carbonoorganico, materiaorganica, pmn, calcio, magnesio, sodio, acideztitulable, cic, sb, zinc, operador, marca FROM suelos ORDER BY id DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSuelos
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FICHA = CType(unaFila.Item(1), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(2), String)
                    s.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s.MUESTRA = CType(unaFila.Item(4), String)
                    s.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    s.FOSFOROBRAY = CType(unaFila.Item(6), Double)
                    s.FOSFOROCITRICO = CType(unaFila.Item(7), Double)
                    s.NITRATOS = CType(unaFila.Item(8), Double)
                    s.PHAGUA = CType(unaFila.Item(9), Double)
                    s.PHKCI = CType(unaFila.Item(10), Double)
                    s.POTASIOINT = CType(unaFila.Item(11), Double)
                    s.SULFATOS = CType(unaFila.Item(12), Double)
                    s.NITROGENOVEGETAL = CType(unaFila.Item(13), Double)
                    s.CARBONOORGANICO = CType(unaFila.Item(14), Double)
                    s.MATERIAORGANICA = CType(unaFila.Item(15), Double)
                    s.PMN = CType(unaFila.Item(16), Double)
                    s.CALCIO = CType(unaFila.Item(17), Double)
                    s.MAGNESIO = CType(unaFila.Item(18), Double)
                    s.SODIO = CType(unaFila.Item(19), Double)
                    s.ACIDEZTITULABLE = CType(unaFila.Item(20), Double)
                    s.CIC = CType(unaFila.Item(21), Double)
                    s.SB = CType(unaFila.Item(22), Double)
                    s.ZINC = CType(unaFila.Item(23), Double)
                    s.OPERADOR = CType(unaFila.Item(24), Integer)
                    s.MARCA = CType(unaFila.Item(25), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM suelos WHERE marca =0 ORDER BY ficha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSuelos
                    s.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, fosforobray, fosforocitrico, nitratos, phagua, phkci, potasioint, sulfatos, nitrogenovegetal, carbonoorganico, materiaorganica, pmn, calcio, magnesio, sodio, acideztitulable, cic, sb, zinc, operador, marca FROM suelos where ficha = " & texto & " order by id desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSuelos
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FICHA = CType(unaFila.Item(1), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(2), String)
                    s.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s.MUESTRA = CType(unaFila.Item(4), String)
                    s.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    s.FOSFOROBRAY = CType(unaFila.Item(6), Double)
                    s.FOSFOROCITRICO = CType(unaFila.Item(7), Double)
                    s.NITRATOS = CType(unaFila.Item(8), Double)
                    s.PHAGUA = CType(unaFila.Item(9), Double)
                    s.PHKCI = CType(unaFila.Item(10), Double)
                    s.POTASIOINT = CType(unaFila.Item(11), Double)
                    s.SULFATOS = CType(unaFila.Item(12), Double)
                    s.NITROGENOVEGETAL = CType(unaFila.Item(13), Double)
                    s.CARBONOORGANICO = CType(unaFila.Item(14), Double)
                    s.MATERIAORGANICA = CType(unaFila.Item(15), Double)
                    s.PMN = CType(unaFila.Item(16), Double)
                    s.CALCIO = CType(unaFila.Item(17), Double)
                    s.MAGNESIO = CType(unaFila.Item(18), Double)
                    s.SODIO = CType(unaFila.Item(19), Double)
                    s.ACIDEZTITULABLE = CType(unaFila.Item(20), Double)
                    s.CIC = CType(unaFila.Item(21), Double)
                    s.SB = CType(unaFila.Item(22), Double)
                    s.ZINC = CType(unaFila.Item(23), Double)
                    s.OPERADOR = CType(unaFila.Item(24), Integer)
                    s.MARCA = CType(unaFila.Item(25), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, fosforobray, fosforocitrico, nitratos, phagua, phkci, potasioint, sulfatos, nitrogenovegetal, carbonoorganico, materiaorganica, pmn, calcio, magnesio, sodio, acideztitulable, cic, sb, zinc, operador, marca FROM suelos where fechaingreso BETWEEN  '" & desde & "' and  '" & hasta & "' AND marca=1 order by fechaingreso asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSuelos
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FICHA = CType(unaFila.Item(1), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(2), String)
                    s.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s.MUESTRA = CType(unaFila.Item(4), String)
                    s.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    s.FOSFOROBRAY = CType(unaFila.Item(6), Double)
                    s.FOSFOROCITRICO = CType(unaFila.Item(7), Double)
                    s.NITRATOS = CType(unaFila.Item(8), Double)
                    s.PHAGUA = CType(unaFila.Item(9), Double)
                    s.PHKCI = CType(unaFila.Item(10), Double)
                    s.POTASIOINT = CType(unaFila.Item(11), Double)
                    s.SULFATOS = CType(unaFila.Item(12), Double)
                    s.NITROGENOVEGETAL = CType(unaFila.Item(13), Double)
                    s.CARBONOORGANICO = CType(unaFila.Item(14), Double)
                    s.MATERIAORGANICA = CType(unaFila.Item(15), Double)
                    s.PMN = CType(unaFila.Item(16), Double)
                    s.CALCIO = CType(unaFila.Item(17), Double)
                    s.MAGNESIO = CType(unaFila.Item(18), Double)
                    s.SODIO = CType(unaFila.Item(19), Double)
                    s.ACIDEZTITULABLE = CType(unaFila.Item(20), Double)
                    s.CIC = CType(unaFila.Item(21), Double)
                    s.SB = CType(unaFila.Item(22), Double)
                    s.ZINC = CType(unaFila.Item(23), Double)
                    s.OPERADOR = CType(unaFila.Item(24), Integer)
                    s.MARCA = CType(unaFila.Item(25), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList

        Dim sql As String = ("select * from nuevoanalisis na inner join solicitudanalisis sa on sa.id = na.ficha inner join muestra m on m.id = sa.idmuestra where na.tipoinforme = 14 and sa.fechaingreso between '" & desde & "' AND '" & hasta & "' AND na.finalizado = 1 order by sa.fechaingreso asc")

        'Dim sql As String = ("select * from nuevoanalisis na inner join solicitudanalisis sa on na.ficha = sa.id where sa.fechaingreso between '" & desde & "' AND '" & hasta & "' AND finalizado=1 order by sa.fechaingreso asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, fosforobray, fosforocitrico, nitratos, phagua, phkci, potasioint, sulfatos, nitrogenovegetal, carbonoorganico, materiaorganica, pmn, calcio, magnesio, sodio, acideztitulable, cic, sb, zinc, operador, marca FROM suelos where ficha = " & texto & " AND marca=0 order by muestra asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSuelos
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FICHA = CType(unaFila.Item(1), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(2), String)
                    s.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s.MUESTRA = CType(unaFila.Item(4), String)
                    s.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    s.FOSFOROBRAY = CType(unaFila.Item(6), Double)
                    s.FOSFOROCITRICO = CType(unaFila.Item(7), Double)
                    s.NITRATOS = CType(unaFila.Item(8), Double)
                    s.PHAGUA = CType(unaFila.Item(9), Double)
                    s.PHKCI = CType(unaFila.Item(10), Double)
                    s.POTASIOINT = CType(unaFila.Item(11), Double)
                    s.SULFATOS = CType(unaFila.Item(12), Double)
                    s.NITROGENOVEGETAL = CType(unaFila.Item(13), Double)
                    s.CARBONOORGANICO = CType(unaFila.Item(14), Double)
                    s.MATERIAORGANICA = CType(unaFila.Item(15), Double)
                    s.PMN = CType(unaFila.Item(16), Double)
                    s.CALCIO = CType(unaFila.Item(17), Double)
                    s.MAGNESIO = CType(unaFila.Item(18), Double)
                    s.SODIO = CType(unaFila.Item(19), Double)
                    s.ACIDEZTITULABLE = CType(unaFila.Item(20), Double)
                    s.CIC = CType(unaFila.Item(21), Double)
                    s.SB = CType(unaFila.Item(22), Double)
                    s.ZINC = CType(unaFila.Item(23), Double)
                    s.OPERADOR = CType(unaFila.Item(24), Integer)
                    s.MARCA = CType(unaFila.Item(25), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, fosforobray, fosforocitrico, nitratos, phagua, phkci, potasioint, sulfatos, nitrogenovegetal, carbonoorganico, materiaorganica, pmn, calcio, magnesio, sodio, acideztitulable, cic, sb, zinc, operador, marca FROM suelos where ficha = " & texto & " AND marca=1 order by muestra asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSuelos
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FICHA = CType(unaFila.Item(1), Long)
                    s.FECHAINGRESO = CType(unaFila.Item(2), String)
                    s.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s.MUESTRA = CType(unaFila.Item(4), String)
                    s.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    s.FOSFOROBRAY = CType(unaFila.Item(6), Double)
                    s.FOSFOROCITRICO = CType(unaFila.Item(7), Double)
                    s.NITRATOS = CType(unaFila.Item(8), Double)
                    s.PHAGUA = CType(unaFila.Item(9), Double)
                    s.PHKCI = CType(unaFila.Item(10), Double)
                    s.POTASIOINT = CType(unaFila.Item(11), Double)
                    s.SULFATOS = CType(unaFila.Item(12), Double)
                    s.NITROGENOVEGETAL = CType(unaFila.Item(13), Double)
                    s.CARBONOORGANICO = CType(unaFila.Item(14), Double)
                    s.MATERIAORGANICA = CType(unaFila.Item(15), Double)
                    s.PMN = CType(unaFila.Item(16), Double)
                    s.CALCIO = CType(unaFila.Item(17), Double)
                    s.MAGNESIO = CType(unaFila.Item(18), Double)
                    s.SODIO = CType(unaFila.Item(19), Double)
                    s.ACIDEZTITULABLE = CType(unaFila.Item(20), Double)
                    s.CIC = CType(unaFila.Item(21), Double)
                    s.SB = CType(unaFila.Item(22), Double)
                    s.ZINC = CType(unaFila.Item(23), Double)
                    s.OPERADOR = CType(unaFila.Item(24), Integer)
                    s.MARCA = CType(unaFila.Item(25), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
