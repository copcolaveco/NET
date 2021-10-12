Public Class pNutricion
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNutricion = CType(o, dNutricion)
        Dim sql As String = "INSERT INTO nutricion (id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, clase, alimento, msh, msmet, cenizash, cenizass, cenizasmet, pbh, pbs, pbmet, fndh, fnds, fndmet, fadh, fads, fadmet, enls, enlmet, ems, emmet, fch, fcs, fcmet, phh, phmet, eeh, ees, eemet, nidah, nidamet,don, donmet,afla, aflamet,zeara, zearamet, fibraefectiva, fibraefectivamet, clostridios, clostridiosmet, zinc, zincmet, calcio, calciomet, fosforo, fosforomet, operador, marca) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.FECHAINGRESO & "','" & obj.FECHAPROCESO & "','" & obj.MUESTRA & "','" & obj.DETALLEMUESTRA & "'," & obj.CLASE & "," & obj.ALIMENTO & "," & obj.MSH & ",  " & obj.MSM & ", " & obj.CENIZASH & "," & obj.CENIZASS & ", " & obj.CENIZASM & ", " & obj.PBH & ", " & obj.PBS & ", " & obj.PBM & "," & obj.FNDH & "," & obj.FNDS & ", " & obj.FNDM & ", " & obj.FADH & "," & obj.FADS & ", " & obj.FADM & "," & obj.ENLS & ", " & obj.ENLM & "," & obj.EMS & ", " & obj.EMM & "," & obj.FCH & "," & obj.FCS & ", " & obj.FCM & "," & obj.PHH & ", " & obj.PHM & "," & obj.EEH & "," & obj.EES & ", " & obj.EEM & "," & obj.NIDAH & ", " & obj.NIDAM & ",'" & obj.DON & "', " & obj.DONM & ",'" & obj.AFLA & "', " & obj.AFLAM & ",'" & obj.ZEARA & "', " & obj.ZEARAM & ",'" & obj.FIBRAEFECTIVA & "', " & obj.FIBRAEFECTIVAM & ",'" & obj.CLOSTRIDIOS & "', " & obj.CLOSTRIDIOSM & ",'" & obj.ZINC & "', " & obj.ZINCM & ",'" & obj.CALCIO & "', " & obj.CALCIOM & ",'" & obj.FOSFORO & "', " & obj.FOSFOROM & ", " & obj.OPERADOR & "," & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nutricion', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNutricion = CType(o, dNutricion)
        Dim sql As String = "UPDATE nutricion SET ficha=" & obj.FICHA & ", fechaingreso='" & obj.FECHAINGRESO & "', fechaproceso='" & obj.FECHAPROCESO & "', muestra='" & obj.MUESTRA & "', detallemuestra='" & obj.DETALLEMUESTRA & "', clase=" & obj.CLASE & ", alimento=" & obj.ALIMENTO & ", msh=" & obj.MSH & ",  msmet= " & obj.MSM & ", cenizash= " & obj.CENIZASH & ",cenizass=" & obj.CENIZASS & ", cenizasmet= " & obj.CENIZASM & ", pbh= " & obj.PBH & ", pbs= " & obj.PBS & ", pbmet= " & obj.PBM & ", fndh=" & obj.FNDH & ", fnds=" & obj.FNDS & ", fndmet= " & obj.FNDM & ", fadh= " & obj.FADH & ", fads=" & obj.FADS & ", fadmet= " & obj.FADM & ",  enls=" & obj.ENLS & ", enlmet= " & obj.ENLM & ", ems=" & obj.EMS & ", emmet= " & obj.EMM & ", fch=" & obj.FCH & ", fcs=" & obj.FCS & ", fcmet= " & obj.FCM & ", phh=" & obj.PHH & ",  phmet= " & obj.PHM & ", eeh=" & obj.EEH & ", ees=" & obj.EES & ", eemet= " & obj.EEM & ", nidah=" & obj.NIDAH & ", nidamet= " & obj.NIDAM & ",don='" & obj.DON & "', donmet= " & obj.DONM & ",afla='" & obj.AFLA & "', aflamet= " & obj.AFLAM & ",zeara='" & obj.ZEARA & "', zearamet= " & obj.ZEARAM & ",fibraefectiva='" & obj.FIBRAEFECTIVA & "', fibraefectivamet= " & obj.FIBRAEFECTIVAM & ",clostridios='" & obj.CLOSTRIDIOS & "', clostridiosmet= " & obj.CLOSTRIDIOSM & ",zinc='" & obj.ZINC & "', zincmet= " & obj.ZINCM & ",calcio='" & obj.CALCIO & "', calciomet= " & obj.CALCIOM & ",fosforo='" & obj.FOSFORO & "', fosforomet= " & obj.FOSFOROM & ", operador= " & obj.OPERADOR & ", marca=" & obj.MARCA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nutricion', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNutricion = CType(o, dNutricion)
        Dim sql As String = "UPDATE nutricion SET marca=" & obj.MARCA & " WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nutricion', 'marcar', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNutricion = CType(o, dNutricion)
        Dim sql As String = "DELETE FROM nutricion WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nutricion', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNutricion = CType(o, dNutricion)
        Dim sql As String = "DELETE FROM nutricion WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nutricion', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dNutricion
        Dim obj As dNutricion = CType(o, dNutricion)
        Dim n As New dNutricion
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, clase, alimento, msh, msmet, cenizash, cenizass, cenizasmet, pbh, pbs, pbmet, fndh, fnds, fndmet, fadh, fads, fadmet, enls, enlmet, ems, emmet, fch, fcs, fcmet, phh, phmet, eeh, ees, eemet, nidah, nidamet,don, donmet,afla, aflamet,zeara, zearamet, fibraefectiva, fibraefectivamet, clostridios, clostridiosmet, zinc, zincmet, calcio, calciomet, fosforo, fosforomet, operador, marca FROM nutricion WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                n.ID = CType(unaFila.Item(0), Long)
                n.FICHA = CType(unaFila.Item(1), Long)
                n.FECHAINGRESO = CType(unaFila.Item(2), String)
                n.FECHAPROCESO = CType(unaFila.Item(3), String)
                n.MUESTRA = CType(unaFila.Item(4), String)
                n.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                n.CLASE = CType(unaFila.Item(6), Integer)
                n.ALIMENTO = CType(unaFila.Item(7), Integer)
                n.MSH = CType(unaFila.Item(8), Double)
                n.MSM = CType(unaFila.Item(9), Integer)
                n.CENIZASH = CType(unaFila.Item(10), Double)
                n.CENIZASS = CType(unaFila.Item(11), Double)
                n.CENIZASM = CType(unaFila.Item(12), Integer)
                n.PBH = CType(unaFila.Item(13), Double)
                n.PBS = CType(unaFila.Item(14), Double)
                n.PBM = CType(unaFila.Item(15), Integer)
                n.FNDH = CType(unaFila.Item(16), Double)
                n.FNDS = CType(unaFila.Item(17), Double)
                n.FNDM = CType(unaFila.Item(18), Integer)
                n.FADH = CType(unaFila.Item(19), Double)
                n.FADS = CType(unaFila.Item(20), Double)
                n.FADM = CType(unaFila.Item(21), Integer)
                n.ENLS = CType(unaFila.Item(22), Double)
                n.ENLM = CType(unaFila.Item(23), Integer)
                n.EMS = CType(unaFila.Item(24), Double)
                n.EMM = CType(unaFila.Item(25), Integer)
                n.FCH = CType(unaFila.Item(26), Double)
                n.FCS = CType(unaFila.Item(27), Double)
                n.FCM = CType(unaFila.Item(28), Integer)
                n.PHH = CType(unaFila.Item(29), Double)
                n.PHM = CType(unaFila.Item(30), Integer)
                n.EEH = CType(unaFila.Item(31), Double)
                n.EES = CType(unaFila.Item(32), Double)
                n.EEM = CType(unaFila.Item(33), Integer)
                n.NIDAH = CType(unaFila.Item(34), Double)
                n.NIDAM = CType(unaFila.Item(35), Integer)
                n.DON = CType(unaFila.Item(36), String)
                n.DONM = CType(unaFila.Item(37), Integer)
                n.AFLA = CType(unaFila.Item(38), String)
                n.AFLAM = CType(unaFila.Item(39), Integer)
                n.ZEARA = CType(unaFila.Item(40), String)
                n.ZEARAM = CType(unaFila.Item(41), Integer)
                n.FIBRAEFECTIVA = CType(unaFila.Item(42), String)
                n.FIBRAEFECTIVAM = CType(unaFila.Item(43), Integer)
                n.CLOSTRIDIOS = CType(unaFila.Item(44), String)
                n.CLOSTRIDIOSM = CType(unaFila.Item(45), Integer)
                n.ZINC = CType(unaFila.Item(46), Double)
                n.ZINCM = CType(unaFila.Item(47), Integer)
                n.CALCIO = CType(unaFila.Item(48), Double)
                n.CALCIOM = CType(unaFila.Item(49), Integer)
                n.FOSFORO = CType(unaFila.Item(50), Double)
                n.FOSFOROM = CType(unaFila.Item(51), Integer)
                n.OPERADOR = CType(unaFila.Item(52), Integer)
                n.MARCA = CType(unaFila.Item(53), Double)
                Return n
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, clase, alimento, msh, msmet, cenizash, cenizass, cenizasmet, pbh, pbs, pbmet, fndh, fnds, fndmet, fadh, fads, fadmet, enls, enlmet, ems, emmet, fch, fcs, fcmet, phh, phmet, eeh, ees, eemet, nidah, nidamet,don, donmet,afla, aflamet,zeara, zearamet, fibraefectiva, fibraefectivamet, clostridios, clostridiosmet, zinc, zincmet, calcio, calciomet, fosforo, fosforomet, operador, marca FROM nutricion ORDER BY id DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNutricion
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.FECHAINGRESO = CType(unaFila.Item(2), String)
                    n.FECHAPROCESO = CType(unaFila.Item(3), String)
                    n.MUESTRA = CType(unaFila.Item(4), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    n.CLASE = CType(unaFila.Item(6), Integer)
                    n.ALIMENTO = CType(unaFila.Item(7), Integer)
                    n.MSH = CType(unaFila.Item(8), Double)
                    n.MSM = CType(unaFila.Item(9), Integer)
                    n.CENIZASH = CType(unaFila.Item(10), Double)
                    n.CENIZASS = CType(unaFila.Item(11), Double)
                    n.CENIZASM = CType(unaFila.Item(12), Integer)
                    n.PBH = CType(unaFila.Item(13), Double)
                    n.PBS = CType(unaFila.Item(14), Double)
                    n.PBM = CType(unaFila.Item(15), Integer)
                    n.FNDH = CType(unaFila.Item(16), Double)
                    n.FNDS = CType(unaFila.Item(17), Double)
                    n.FNDM = CType(unaFila.Item(18), Integer)
                    n.FADH = CType(unaFila.Item(19), Double)
                    n.FADS = CType(unaFila.Item(20), Double)
                    n.FADM = CType(unaFila.Item(21), Integer)
                    n.ENLS = CType(unaFila.Item(22), Double)
                    n.ENLM = CType(unaFila.Item(23), Integer)
                    n.EMS = CType(unaFila.Item(24), Double)
                    n.EMM = CType(unaFila.Item(25), Integer)
                    n.FCH = CType(unaFila.Item(26), Double)
                    n.FCS = CType(unaFila.Item(27), Double)
                    n.FCM = CType(unaFila.Item(28), Integer)
                    n.PHH = CType(unaFila.Item(29), Double)
                    n.PHM = CType(unaFila.Item(30), Integer)
                    n.EEH = CType(unaFila.Item(31), Double)
                    n.EES = CType(unaFila.Item(32), Double)
                    n.EEM = CType(unaFila.Item(33), Integer)
                    n.NIDAH = CType(unaFila.Item(34), Double)
                    n.NIDAM = CType(unaFila.Item(35), Integer)
                    n.DON = CType(unaFila.Item(36), String)
                    n.DONM = CType(unaFila.Item(37), Integer)
                    n.AFLA = CType(unaFila.Item(38), String)
                    n.AFLAM = CType(unaFila.Item(39), Integer)
                    n.ZEARA = CType(unaFila.Item(40), String)
                    n.ZEARAM = CType(unaFila.Item(41), Integer)
                    n.FIBRAEFECTIVA = CType(unaFila.Item(42), String)
                    n.FIBRAEFECTIVAM = CType(unaFila.Item(43), Integer)
                    n.CLOSTRIDIOS = CType(unaFila.Item(44), String)
                    n.CLOSTRIDIOSM = CType(unaFila.Item(45), Integer)
                    n.ZINC = CType(unaFila.Item(46), Double)
                    n.ZINCM = CType(unaFila.Item(47), Integer)
                    n.CALCIO = CType(unaFila.Item(48), Double)
                    n.CALCIOM = CType(unaFila.Item(49), Integer)
                    n.FOSFORO = CType(unaFila.Item(50), Double)
                    n.FOSFOROM = CType(unaFila.Item(51), Integer)
                    n.OPERADOR = CType(unaFila.Item(52), Integer)
                    n.MARCA = CType(unaFila.Item(53), Double)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM nutricion WHERE marca =0 ORDER BY ficha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNutricion
                    n.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, clase, alimento, msh, msmet, cenizash, cenizass, cenizasmet, pbh, pbs, pbmet, fndh, fnds, fndmet, fadh, fads, fadmet, enls, enlmet, ems, emmet, fch, fcs, fcmet, phh, phmet, eeh, ees, eemet, nidah, nidamet,don, donmet,afla, aflamet,zeara, zearamet, fibraefectiva, fibraefectivamet, clostridios, clostridiosmet, zinc, zincmet, calcio, calciomet, fosforo, fosforomet, operador, marca FROM nutricion where ficha = " & texto & " order by id desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNutricion
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.FECHAINGRESO = CType(unaFila.Item(2), String)
                    n.FECHAPROCESO = CType(unaFila.Item(3), String)
                    n.MUESTRA = CType(unaFila.Item(4), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    n.CLASE = CType(unaFila.Item(6), Integer)
                    n.ALIMENTO = CType(unaFila.Item(7), Integer)
                    n.MSH = CType(unaFila.Item(8), Double)
                    n.MSM = CType(unaFila.Item(9), Integer)
                    n.CENIZASH = CType(unaFila.Item(10), Double)
                    n.CENIZASS = CType(unaFila.Item(11), Double)
                    n.CENIZASM = CType(unaFila.Item(12), Integer)
                    n.PBH = CType(unaFila.Item(13), Double)
                    n.PBS = CType(unaFila.Item(14), Double)
                    n.PBM = CType(unaFila.Item(15), Integer)
                    n.FNDH = CType(unaFila.Item(16), Double)
                    n.FNDS = CType(unaFila.Item(17), Double)
                    n.FNDM = CType(unaFila.Item(18), Integer)
                    n.FADH = CType(unaFila.Item(19), Double)
                    n.FADS = CType(unaFila.Item(20), Double)
                    n.FADM = CType(unaFila.Item(21), Integer)
                    n.ENLS = CType(unaFila.Item(22), Double)
                    n.ENLM = CType(unaFila.Item(23), Integer)
                    n.EMS = CType(unaFila.Item(24), Double)
                    n.EMM = CType(unaFila.Item(25), Integer)
                    n.FCH = CType(unaFila.Item(26), Double)
                    n.FCS = CType(unaFila.Item(27), Double)
                    n.FCM = CType(unaFila.Item(28), Integer)
                    n.PHH = CType(unaFila.Item(29), Double)
                    n.PHM = CType(unaFila.Item(30), Integer)
                    n.EEH = CType(unaFila.Item(31), Double)
                    n.EES = CType(unaFila.Item(32), Double)
                    n.EEM = CType(unaFila.Item(33), Integer)
                    n.NIDAH = CType(unaFila.Item(34), Double)
                    n.NIDAM = CType(unaFila.Item(35), Integer)
                    n.DON = CType(unaFila.Item(36), String)
                    n.DONM = CType(unaFila.Item(37), Integer)
                    n.AFLA = CType(unaFila.Item(38), String)
                    n.AFLAM = CType(unaFila.Item(39), Integer)
                    n.ZEARA = CType(unaFila.Item(40), String)
                    n.ZEARAM = CType(unaFila.Item(41), Integer)
                    n.FIBRAEFECTIVA = CType(unaFila.Item(42), String)
                    n.FIBRAEFECTIVAM = CType(unaFila.Item(43), Integer)
                    n.CLOSTRIDIOS = CType(unaFila.Item(44), String)
                    n.CLOSTRIDIOSM = CType(unaFila.Item(45), Integer)
                    n.ZINC = CType(unaFila.Item(46), Double)
                    n.ZINCM = CType(unaFila.Item(47), Integer)
                    n.CALCIO = CType(unaFila.Item(48), Double)
                    n.CALCIOM = CType(unaFila.Item(49), Integer)
                    n.FOSFORO = CType(unaFila.Item(50), Double)
                    n.FOSFOROM = CType(unaFila.Item(51), Integer)
                    n.OPERADOR = CType(unaFila.Item(52), Integer)
                    n.MARCA = CType(unaFila.Item(53), Double)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, clase, alimento, msh, msmet, cenizash, cenizass, cenizasmet, pbh, pbs, pbmet, fndh, fnds, fndmet, fadh, fads, fadmet, enls, enlmet, ems, emmet, fch, fcs, fcmet, phh, phmet, eeh, ees, eemet, nidah, nidamet,don, donmet,afla, aflamet,zeara, zearamet, fibraefectiva, fibraefectivamet, clostridios, clostridiosmet, zinc, zincmet, calcio, calciomet, fosforo, fosforomet, operador, marca FROM nutricion where ficha = " & texto & " order by muestra asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNutricion
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.FECHAINGRESO = CType(unaFila.Item(2), String)
                    n.FECHAPROCESO = CType(unaFila.Item(3), String)
                    n.MUESTRA = CType(unaFila.Item(4), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    n.CLASE = CType(unaFila.Item(6), Integer)
                    n.ALIMENTO = CType(unaFila.Item(7), Integer)
                    n.MSH = CType(unaFila.Item(8), Double)
                    n.MSM = CType(unaFila.Item(9), Integer)
                    n.CENIZASH = CType(unaFila.Item(10), Double)
                    n.CENIZASS = CType(unaFila.Item(11), Double)
                    n.CENIZASM = CType(unaFila.Item(12), Integer)
                    n.PBH = CType(unaFila.Item(13), Double)
                    n.PBS = CType(unaFila.Item(14), Double)
                    n.PBM = CType(unaFila.Item(15), Integer)
                    n.FNDH = CType(unaFila.Item(16), Double)
                    n.FNDS = CType(unaFila.Item(17), Double)
                    n.FNDM = CType(unaFila.Item(18), Integer)
                    n.FADH = CType(unaFila.Item(19), Double)
                    n.FADS = CType(unaFila.Item(20), Double)
                    n.FADM = CType(unaFila.Item(21), Integer)
                    n.ENLS = CType(unaFila.Item(22), Double)
                    n.ENLM = CType(unaFila.Item(23), Integer)
                    n.EMS = CType(unaFila.Item(24), Double)
                    n.EMM = CType(unaFila.Item(25), Integer)
                    n.FCH = CType(unaFila.Item(26), Double)
                    n.FCS = CType(unaFila.Item(27), Double)
                    n.FCM = CType(unaFila.Item(28), Integer)
                    n.PHH = CType(unaFila.Item(29), Double)
                    n.PHM = CType(unaFila.Item(30), Integer)
                    n.EEH = CType(unaFila.Item(31), Double)
                    n.EES = CType(unaFila.Item(32), Double)
                    n.EEM = CType(unaFila.Item(33), Integer)
                    n.NIDAH = CType(unaFila.Item(34), Double)
                    n.NIDAM = CType(unaFila.Item(35), Integer)
                    n.DON = CType(unaFila.Item(36), String)
                    n.DONM = CType(unaFila.Item(37), Integer)
                    n.AFLA = CType(unaFila.Item(38), String)
                    n.AFLAM = CType(unaFila.Item(39), Integer)
                    n.ZEARA = CType(unaFila.Item(40), String)
                    n.ZEARAM = CType(unaFila.Item(41), Integer)
                    n.FIBRAEFECTIVA = CType(unaFila.Item(42), String)
                    n.FIBRAEFECTIVAM = CType(unaFila.Item(43), Integer)
                    n.CLOSTRIDIOS = CType(unaFila.Item(44), String)
                    n.CLOSTRIDIOSM = CType(unaFila.Item(45), Integer)
                    n.ZINC = CType(unaFila.Item(46), Double)
                    n.ZINCM = CType(unaFila.Item(47), Integer)
                    n.CALCIO = CType(unaFila.Item(48), Double)
                    n.CALCIOM = CType(unaFila.Item(49), Integer)
                    n.FOSFORO = CType(unaFila.Item(50), Double)
                    n.FOSFOROM = CType(unaFila.Item(51), Integer)
                    n.OPERADOR = CType(unaFila.Item(52), Integer)
                    n.MARCA = CType(unaFila.Item(53), Double)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, clase, alimento, msh, msmet, cenizash, cenizass, cenizasmet, pbh, pbs, pbmet, fndh, fnds, fndmet, fadh, fads, fadmet, enls, enlmet, ems, emmet, fch, fcs, fcmet, phh, phmet, eeh, ees, eemet, nidah, nidamet,don, donmet,afla, aflamet,zeara, zearamet, fibraefectiva, fibraefectivamet, clostridios, clostridiosmet, zinc, zincmet, calcio, calciomet, fosforo, fosforomet, operador, marca FROM nutricion where ficha = " & texto & " AND marca=1 order by muestra asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNutricion
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.FECHAINGRESO = CType(unaFila.Item(2), String)
                    n.FECHAPROCESO = CType(unaFila.Item(3), String)
                    n.MUESTRA = CType(unaFila.Item(4), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    n.CLASE = CType(unaFila.Item(6), Integer)
                    n.ALIMENTO = CType(unaFila.Item(7), Integer)
                    n.MSH = CType(unaFila.Item(8), Double)
                    n.MSM = CType(unaFila.Item(9), Integer)
                    n.CENIZASH = CType(unaFila.Item(10), Double)
                    n.CENIZASS = CType(unaFila.Item(11), Double)
                    n.CENIZASM = CType(unaFila.Item(12), Integer)
                    n.PBH = CType(unaFila.Item(13), Double)
                    n.PBS = CType(unaFila.Item(14), Double)
                    n.PBM = CType(unaFila.Item(15), Integer)
                    n.FNDH = CType(unaFila.Item(16), Double)
                    n.FNDS = CType(unaFila.Item(17), Double)
                    n.FNDM = CType(unaFila.Item(18), Integer)
                    n.FADH = CType(unaFila.Item(19), Double)
                    n.FADS = CType(unaFila.Item(20), Double)
                    n.FADM = CType(unaFila.Item(21), Integer)
                    n.ENLS = CType(unaFila.Item(22), Double)
                    n.ENLM = CType(unaFila.Item(23), Integer)
                    n.EMS = CType(unaFila.Item(24), Double)
                    n.EMM = CType(unaFila.Item(25), Integer)
                    n.FCH = CType(unaFila.Item(26), Double)
                    n.FCS = CType(unaFila.Item(27), Double)
                    n.FCM = CType(unaFila.Item(28), Integer)
                    n.PHH = CType(unaFila.Item(29), Double)
                    n.PHM = CType(unaFila.Item(30), Integer)
                    n.EEH = CType(unaFila.Item(31), Double)
                    n.EES = CType(unaFila.Item(32), Double)
                    n.EEM = CType(unaFila.Item(33), Integer)
                    n.NIDAH = CType(unaFila.Item(34), Double)
                    n.NIDAM = CType(unaFila.Item(35), Integer)
                    n.DON = CType(unaFila.Item(36), String)
                    n.DONM = CType(unaFila.Item(37), Integer)
                    n.AFLA = CType(unaFila.Item(38), String)
                    n.AFLAM = CType(unaFila.Item(39), Integer)
                    n.ZEARA = CType(unaFila.Item(40), String)
                    n.ZEARAM = CType(unaFila.Item(41), Integer)
                    n.FIBRAEFECTIVA = CType(unaFila.Item(42), String)
                    n.FIBRAEFECTIVAM = CType(unaFila.Item(43), Integer)
                    n.CLOSTRIDIOS = CType(unaFila.Item(44), String)
                    n.CLOSTRIDIOSM = CType(unaFila.Item(45), Integer)
                    n.ZINC = CType(unaFila.Item(46), Double)
                    n.ZINCM = CType(unaFila.Item(47), Integer)
                    n.CALCIO = CType(unaFila.Item(48), Double)
                    n.CALCIOM = CType(unaFila.Item(49), Integer)
                    n.FOSFORO = CType(unaFila.Item(50), Double)
                    n.FOSFOROM = CType(unaFila.Item(51), Integer)
                    n.OPERADOR = CType(unaFila.Item(52), Integer)
                    n.MARCA = CType(unaFila.Item(53), Double)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfechaxclasexalimento(ByVal desde As String, ByVal hasta As String, ByVal clase As Integer, ByVal alimento As Integer) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, clase, alimento, msh, msmet, cenizash, cenizass, cenizasmet, pbh, pbs, pbmet, fndh, fnds, fndmet, fadh, fads, fadmet, enls, enlmet, ems, emmet, fch, fcs, fcmet, phh, phmet, eeh, ees, eemet, nidah, nidamet,don, donmet,afla, aflamet,zeara, zearamet, fibraefectiva, fibraefectivamet, clostridios, clostridiosmet, zinc, zincmet, calcio, calciomet, fosforo, fosforomet, operador, marca FROM nutricion where fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND clase = " & clase & " AND alimento = " & alimento & " AND marca=1 order by fechaingreso asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNutricion
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.FECHAINGRESO = CType(unaFila.Item(2), String)
                    n.FECHAPROCESO = CType(unaFila.Item(3), String)
                    n.MUESTRA = CType(unaFila.Item(4), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    n.CLASE = CType(unaFila.Item(6), Integer)
                    n.ALIMENTO = CType(unaFila.Item(7), Integer)
                    n.MSH = CType(unaFila.Item(8), Double)
                    n.MSM = CType(unaFila.Item(9), Integer)
                    n.CENIZASH = CType(unaFila.Item(10), Double)
                    n.CENIZASS = CType(unaFila.Item(11), Double)
                    n.CENIZASM = CType(unaFila.Item(12), Integer)
                    n.PBH = CType(unaFila.Item(13), Double)
                    n.PBS = CType(unaFila.Item(14), Double)
                    n.PBM = CType(unaFila.Item(15), Integer)
                    n.FNDH = CType(unaFila.Item(16), Double)
                    n.FNDS = CType(unaFila.Item(17), Double)
                    n.FNDM = CType(unaFila.Item(18), Integer)
                    n.FADH = CType(unaFila.Item(19), Double)
                    n.FADS = CType(unaFila.Item(20), Double)
                    n.FADM = CType(unaFila.Item(21), Integer)
                    n.ENLS = CType(unaFila.Item(22), Double)
                    n.ENLM = CType(unaFila.Item(23), Integer)
                    n.EMS = CType(unaFila.Item(24), Double)
                    n.EMM = CType(unaFila.Item(25), Integer)
                    n.FCH = CType(unaFila.Item(26), Double)
                    n.FCS = CType(unaFila.Item(27), Double)
                    n.FCM = CType(unaFila.Item(28), Integer)
                    n.PHH = CType(unaFila.Item(29), Double)
                    n.PHM = CType(unaFila.Item(30), Integer)
                    n.EEH = CType(unaFila.Item(31), Double)
                    n.EES = CType(unaFila.Item(32), Double)
                    n.EEM = CType(unaFila.Item(33), Integer)
                    n.NIDAH = CType(unaFila.Item(34), Double)
                    n.NIDAM = CType(unaFila.Item(35), Integer)
                    n.DON = CType(unaFila.Item(36), String)
                    n.DONM = CType(unaFila.Item(37), Integer)
                    n.AFLA = CType(unaFila.Item(38), String)
                    n.AFLAM = CType(unaFila.Item(39), Integer)
                    n.ZEARA = CType(unaFila.Item(40), String)
                    n.ZEARAM = CType(unaFila.Item(41), Integer)
                    n.FIBRAEFECTIVA = CType(unaFila.Item(42), String)
                    n.FIBRAEFECTIVAM = CType(unaFila.Item(43), Integer)
                    n.CLOSTRIDIOS = CType(unaFila.Item(44), String)
                    n.CLOSTRIDIOSM = CType(unaFila.Item(45), Integer)
                    n.ZINC = CType(unaFila.Item(46), Double)
                    n.ZINCM = CType(unaFila.Item(47), Integer)
                    n.CALCIO = CType(unaFila.Item(48), Double)
                    n.CALCIOM = CType(unaFila.Item(49), Integer)
                    n.FOSFORO = CType(unaFila.Item(50), Double)
                    n.FOSFOROM = CType(unaFila.Item(51), Integer)
                    n.OPERADOR = CType(unaFila.Item(52), Integer)
                    n.MARCA = CType(unaFila.Item(53), Double)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, clase, alimento, msh, msmet, cenizash, cenizass, cenizasmet, pbh, pbs, pbmet, fndh, fnds, fndmet, fadh, fads, fadmet, enls, enlmet, ems, emmet, fch, fcs, fcmet, phh, phmet, eeh, ees, eemet, nidah, nidamet,don, donmet,afla, aflamet,zeara, zearamet, fibraefectiva, fibraefectivamet, clostridios, clostridiosmet, zinc, zincmet, calcio, calciomet, fosforo, fosforomet, operador, marca FROM nutricion where fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND marca=1 order by fechaingreso asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNutricion
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.FECHAINGRESO = CType(unaFila.Item(2), String)
                    n.FECHAPROCESO = CType(unaFila.Item(3), String)
                    n.MUESTRA = CType(unaFila.Item(4), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    n.CLASE = CType(unaFila.Item(6), Integer)
                    n.ALIMENTO = CType(unaFila.Item(7), Integer)
                    n.MSH = CType(unaFila.Item(8), Double)
                    n.MSM = CType(unaFila.Item(9), Integer)
                    n.CENIZASH = CType(unaFila.Item(10), Double)
                    n.CENIZASS = CType(unaFila.Item(11), Double)
                    n.CENIZASM = CType(unaFila.Item(12), Integer)
                    n.PBH = CType(unaFila.Item(13), Double)
                    n.PBS = CType(unaFila.Item(14), Double)
                    n.PBM = CType(unaFila.Item(15), Integer)
                    n.FNDH = CType(unaFila.Item(16), Double)
                    n.FNDS = CType(unaFila.Item(17), Double)
                    n.FNDM = CType(unaFila.Item(18), Integer)
                    n.FADH = CType(unaFila.Item(19), Double)
                    n.FADS = CType(unaFila.Item(20), Double)
                    n.FADM = CType(unaFila.Item(21), Integer)
                    n.ENLS = CType(unaFila.Item(22), Double)
                    n.ENLM = CType(unaFila.Item(23), Integer)
                    n.EMS = CType(unaFila.Item(24), Double)
                    n.EMM = CType(unaFila.Item(25), Integer)
                    n.FCH = CType(unaFila.Item(26), Double)
                    n.FCS = CType(unaFila.Item(27), Double)
                    n.FCM = CType(unaFila.Item(28), Integer)
                    n.PHH = CType(unaFila.Item(29), Double)
                    n.PHM = CType(unaFila.Item(30), Integer)
                    n.EEH = CType(unaFila.Item(31), Double)
                    n.EES = CType(unaFila.Item(32), Double)
                    n.EEM = CType(unaFila.Item(33), Integer)
                    n.NIDAH = CType(unaFila.Item(34), Double)
                    n.NIDAM = CType(unaFila.Item(35), Integer)
                    n.DON = CType(unaFila.Item(36), String)
                    n.DONM = CType(unaFila.Item(37), Integer)
                    n.AFLA = CType(unaFila.Item(38), String)
                    n.AFLAM = CType(unaFila.Item(39), Integer)
                    n.ZEARA = CType(unaFila.Item(40), String)
                    n.ZEARAM = CType(unaFila.Item(41), Integer)
                    n.FIBRAEFECTIVA = CType(unaFila.Item(42), String)
                    n.FIBRAEFECTIVAM = CType(unaFila.Item(43), Integer)
                    n.CLOSTRIDIOS = CType(unaFila.Item(44), String)
                    n.CLOSTRIDIOSM = CType(unaFila.Item(45), Integer)
                    n.ZINC = CType(unaFila.Item(46), Double)
                    n.ZINCM = CType(unaFila.Item(47), Integer)
                    n.CALCIO = CType(unaFila.Item(48), Double)
                    n.CALCIOM = CType(unaFila.Item(49), Integer)
                    n.FOSFORO = CType(unaFila.Item(50), Double)
                    n.FOSFOROM = CType(unaFila.Item(51), Integer)
                    n.OPERADOR = CType(unaFila.Item(52), Integer)
                    n.MARCA = CType(unaFila.Item(53), Double)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfechaxclase(ByVal desde As String, ByVal hasta As String, ByVal clase As Integer) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaingreso, fechaproceso, muestra, detallemuestra, clase, alimento, msh, msmet, cenizash, cenizass, cenizasmet, pbh, pbs, pbmet, fndh, fnds, fndmet, fadh, fads, fadmet, enls, enlmet, ems, emmet, fch, fcs, fcmet, phh, phmet, eeh, ees, eemet, nidah, nidamet,don, donmet,afla, aflamet,zeara, zearamet, fibraefectiva, fibraefectivamet, clostridios, clostridiosmet, zinc, zincmet, calcio, calciomet, fosforo, fosforomet, operador, marca FROM nutricion where fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' AND clase = " & clase & " AND marca=1 order by fechaingreso asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNutricion
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.FECHAINGRESO = CType(unaFila.Item(2), String)
                    n.FECHAPROCESO = CType(unaFila.Item(3), String)
                    n.MUESTRA = CType(unaFila.Item(4), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    n.CLASE = CType(unaFila.Item(6), Integer)
                    n.ALIMENTO = CType(unaFila.Item(7), Integer)
                    n.MSH = CType(unaFila.Item(8), Double)
                    n.MSM = CType(unaFila.Item(9), Integer)
                    n.CENIZASH = CType(unaFila.Item(10), Double)
                    n.CENIZASS = CType(unaFila.Item(11), Double)
                    n.CENIZASM = CType(unaFila.Item(12), Integer)
                    n.PBH = CType(unaFila.Item(13), Double)
                    n.PBS = CType(unaFila.Item(14), Double)
                    n.PBM = CType(unaFila.Item(15), Integer)
                    n.FNDH = CType(unaFila.Item(16), Double)
                    n.FNDS = CType(unaFila.Item(17), Double)
                    n.FNDM = CType(unaFila.Item(18), Integer)
                    n.FADH = CType(unaFila.Item(19), Double)
                    n.FADS = CType(unaFila.Item(20), Double)
                    n.FADM = CType(unaFila.Item(21), Integer)
                    n.ENLS = CType(unaFila.Item(22), Double)
                    n.ENLM = CType(unaFila.Item(23), Integer)
                    n.EMS = CType(unaFila.Item(24), Double)
                    n.EMM = CType(unaFila.Item(25), Integer)
                    n.FCH = CType(unaFila.Item(26), Double)
                    n.FCS = CType(unaFila.Item(27), Double)
                    n.FCM = CType(unaFila.Item(28), Integer)
                    n.PHH = CType(unaFila.Item(29), Double)
                    n.PHM = CType(unaFila.Item(30), Integer)
                    n.EEH = CType(unaFila.Item(31), Double)
                    n.EES = CType(unaFila.Item(32), Double)
                    n.EEM = CType(unaFila.Item(33), Integer)
                    n.NIDAH = CType(unaFila.Item(34), Double)
                    n.NIDAM = CType(unaFila.Item(35), Integer)
                    n.DON = CType(unaFila.Item(36), String)
                    n.DONM = CType(unaFila.Item(37), Integer)
                    n.AFLA = CType(unaFila.Item(38), String)
                    n.AFLAM = CType(unaFila.Item(39), Integer)
                    n.ZEARA = CType(unaFila.Item(40), String)
                    n.ZEARAM = CType(unaFila.Item(41), Integer)
                    n.FIBRAEFECTIVA = CType(unaFila.Item(42), String)
                    n.FIBRAEFECTIVAM = CType(unaFila.Item(43), Integer)
                    n.CLOSTRIDIOS = CType(unaFila.Item(44), String)
                    n.CLOSTRIDIOSM = CType(unaFila.Item(45), Integer)
                    n.ZINC = CType(unaFila.Item(46), Double)
                    n.ZINCM = CType(unaFila.Item(47), Integer)
                    n.CALCIO = CType(unaFila.Item(48), Double)
                    n.CALCIOM = CType(unaFila.Item(49), Integer)
                    n.FOSFORO = CType(unaFila.Item(50), Double)
                    n.FOSFOROM = CType(unaFila.Item(51), Integer)
                    n.OPERADOR = CType(unaFila.Item(52), Integer)
                    n.MARCA = CType(unaFila.Item(53), Double)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function desmarcarficha(ByVal o As Object) As Boolean
        Dim obj As dNutricion = CType(o, dNutricion)
        Dim sql As String = "UPDATE nutricion SET marca = 0 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
End Class
