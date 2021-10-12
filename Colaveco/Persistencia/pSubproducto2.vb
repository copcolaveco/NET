Public Class pSubproducto2
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSubproducto2 = CType(o, dSubproducto2)
        Dim sql As String = "INSERT INTO subproductos2 (id, ficha, fechasolicitud, fechaproceso, idmuestra, detallemuestra, observaciones, estadomuestra, estafcoagpositivo, estafcoagpositivo_met, cf, cf_met, mohos, mohos_met, levaduras, levaduras_met, ct, ct_met, ecoli, ecoli_met,ecoli157, ecoli157_met, salmonella, salmonella_met, listeriaspp, listeriaspp_met, humedad, humedad_met, mgrasa, mgrasa_met, ph, ph_met, cloruros, cloruros_met, proteinas, proteinas_met, enterobacterias, enterobacterias_met, listeriaambiental, listeriaambiental2, listeriaambiental_met, esporanaermesofilo, esporanaer_met, termofilos, termofilos_met, psicrotrofos, psicrotrofos_met, rb,rb_met, tablanutricional, tnproteina,tncarbohidratos, tngrasastotales, tngrasassaturadas, tngrasastrans, listeriamonocitogenes, listeriamono_met, cenizas, cenizas_met, tnsodio, tnfibraalimenticia, codigoanalitico, tipomuestra, operador, marca) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.FECHASOLICITUD & "', '" & obj.FECHAPROCESO & "','" & obj.IDMUESTRA & "','" & obj.DETALLEMUESTRA & "','" & obj.OBSERVACIONES & "','" & obj.ESTADOMUESTRA & "','" & obj.ESTAFCOAGPOSITIVO & "', " & obj.ESTAFCOAGPOSITIVO_MET & ",'" & obj.CF & "', " & obj.CF_MET & ",'" & obj.MOHOS & "'," & obj.MOHOS_MET & ",'" & obj.LEVADURAS & "'," & obj.LEVADURAS_MET & ",'" & obj.CT & "'," & obj.CT_MET & ", '" & obj.ECOLI & "'," & obj.ECOLI_MET & ", '" & obj.ECOLI157 & "'," & obj.ECOLI157_MET & ", " & obj.SALMONELLA & "," & obj.SALMONELLA_MET & ", " & obj.LISTERIASPP & "," & obj.LISTERIASPP_MET & ", " & obj.HUMEDAD & "," & obj.HUMEDAD_MET & ", " & obj.MGRASA & "," & obj.MGRASA_MET & ", " & obj.PH & "," & obj.PH_MET & "," & obj.CLORUROS & "," & obj.CLORUROS_MET & "," & obj.PROTEINAS & "," & obj.PROTEINAS_MET & ",'" & obj.ENTEROBACTERIAS & "'," & obj.ENTEROBACTERIAS_MET & "," & obj.LISTERIAAMBIENTAL & "," & obj.LISTERIAAMBIENTAL2 & "," & obj.LISTERIAAMBIENTAL_MET & "," & obj.ESPORANAERMESOFILO & "," & obj.ESPORANAERMESOFILO_MET & ",'" & obj.TERMOFILOS & "'," & obj.TERMOFILOS_MET & ",'" & obj.PSICROTROFOS & "'," & obj.PSICROTROFOS_MET & ",'" & obj.RB & "'," & obj.RB_MET & "," & obj.TABLANUTRICIONAL & "," & obj.TNPROTEINA & "," & obj.TNCARBOHIDRATOS & "," & obj.TNGRASASTOTALES & "," & obj.TNGRASASSATURADAS & "," & obj.TNGRASASTRANS & "," & obj.LISTERIAMONOCITOGENES & "," & obj.LISTERIAMONOCITOGENES_MET & "," & obj.CENIZAS & "," & obj.CENIZAS_MET & "," & obj.TNSODIO & "," & obj.TNFIBRAALIMENTICIA & ",'" & obj.CODIGOANALITICO & "', " & obj.TIPOMUESTRA & ", " & obj.OPERADOR & "," & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'subproductos2', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSubproducto2 = CType(o, dSubproducto2)
        Dim sql As String = "UPDATE subproductos2 SET ficha = " & obj.FICHA & ",  fechasolicitud ='" & obj.FECHASOLICITUD & "', fechaproceso ='" & obj.FECHAPROCESO & "',idmuestra ='" & obj.IDMUESTRA & "',detallemuestra ='" & obj.DETALLEMUESTRA & "',observaciones ='" & obj.OBSERVACIONES & "',estadomuestra ='" & obj.ESTADOMUESTRA & "',estafcoagpositivo='" & obj.ESTAFCOAGPOSITIVO & "', estafcoagpositivo_met=" & obj.ESTAFCOAGPOSITIVO_MET & ", cf='" & obj.CF & "', cf_met=" & obj.CF_MET & ", mohos='" & obj.MOHOS & "', mohos_met=" & obj.MOHOS_MET & ", levaduras='" & obj.LEVADURAS & "', levaduras_met=" & obj.LEVADURAS_MET & ", ct='" & obj.CT & "', ct_met=" & obj.CT_MET & ", ecoli='" & obj.ECOLI & "', ecoli_met=" & obj.ECOLI_MET & ",ecoli157='" & obj.ECOLI157 & "', ecoli157_met=" & obj.ECOLI157_MET & ", salmonella=" & obj.SALMONELLA & ", salmonella_met=" & obj.SALMONELLA_MET & ", listeriaspp=" & obj.LISTERIASPP & ", listeriaspp_met=" & obj.LISTERIASPP_MET & ", humedad=" & obj.HUMEDAD & ", humedad_met=" & obj.HUMEDAD_MET & ", mgrasa=" & obj.MGRASA & ", mgrasa_met=" & obj.MGRASA_MET & ", ph=" & obj.PH & ", ph_met=" & obj.PH_MET & ", cloruros=" & obj.CLORUROS & ", cloruros_met=" & obj.CLORUROS_MET & ", proteinas=" & obj.PROTEINAS & ", proteinas_met=" & obj.PROTEINAS_MET & ", enterobacterias='" & obj.ENTEROBACTERIAS & "', enterobacterias_met=" & obj.ENTEROBACTERIAS_MET & ", listeriaambiental=" & obj.LISTERIAAMBIENTAL & ", listeriaambiental2=" & obj.LISTERIAAMBIENTAL2 & ", listeriaambiental_met=" & obj.LISTERIAAMBIENTAL_MET & ", esporanaermesofilo=" & obj.ESPORANAERMESOFILO & ", esporanaer_met=" & obj.ESPORANAERMESOFILO_MET & ", termofilos='" & obj.TERMOFILOS & "', termofilos_met=" & obj.TERMOFILOS_MET & ", psicrotrofos='" & obj.PSICROTROFOS & "', psicrotrofos_met=" & obj.PSICROTROFOS_MET & ",rb='" & obj.RB & "', rb_met=" & obj.RB_MET & ",tablanutricional=" & obj.TABLANUTRICIONAL & ", tnproteina=" & obj.TNPROTEINA & ", tncarbohidratos=" & obj.TNCARBOHIDRATOS & ", tngrasastotales=" & obj.TNGRASASTOTALES & ", tngrasassaturadas=" & obj.TNGRASASSATURADAS & ", tngrasastrans=" & obj.TNGRASASTRANS & ", listeriamonocitogenes=" & obj.LISTERIAMONOCITOGENES & ", listeriamono_met=" & obj.LISTERIAMONOCITOGENES_MET & ", cenizas=" & obj.CENIZAS & ", cenizas_met=" & obj.CENIZAS_MET & ", tnsodio=" & obj.TNSODIO & ", tnfibraalimenticia=" & obj.TNFIBRAALIMENTICIA & ", operador=" & obj.OPERADOR & ", codigoanalitico='" & obj.CODIGOANALITICO & "', tipomuestra=" & obj.TIPOMUESTRA & ", marca=" & obj.MARCA & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'subproductos2', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSubproducto2 = CType(o, dSubproducto2)
        Dim sql As String = "UPDATE subproductos2 SET marca=" & obj.MARCA & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'subproductos2', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarficha(ByVal o As Object) As Boolean
        Dim obj As dSubproducto2 = CType(o, dSubproducto2)
        Dim sql As String = "UPDATE subproductos2 SET marca = 0 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSubproducto2 = CType(o, dSubproducto2)
        Dim sql As String = "DELETE FROM subproductos2 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'subproductos2', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dSubproducto2
        Dim obj As dSubproducto2 = CType(o, dSubproducto2)
        Dim s2 As New dSubproducto2
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fechasolicitud, fechaproceso, idmuestra, detallemuestra, observaciones, estadomuestra, estafcoagpositivo, estafcoagpositivo_met, cf, cf_met, mohos, mohos_met, levaduras, levaduras_met, ct, ct_met, ecoli, ecoli_met,ecoli157, ecoli157_met, salmonella, salmonella_met, listeriaspp, listeriaspp_met, humedad, humedad_met, mgrasa, mgrasa_met, ph, ph_met, cloruros, cloruros_met, proteinas, proteinas_met, enterobacterias, enterobacterias_met, listeriaambiental, listeriaambiental2, listeriaambiental_met, esporanaermesofilo, esporanaer_met, termofilos, termofilos_met, psicrotrofos, psicrotrofos_met, rb,rb_met, tablanutricional, tnproteina,tncarbohidratos, tngrasastotales, tngrasassaturadas, tngrasastrans, listeriamonocitogenes, listeriamono_met, cenizas, cenizas_met, tnsodio, tnfibraalimenticia, ifnull(codigoanalitico,''), tipomuestra, operador, marca FROM subproductos2 WHERE ficha = " & obj.ID & "")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s2.ID = CType(unaFila.Item(0), Long)
                s2.ficha = CType(unaFila.Item(1), Long)
                s2.FECHASOLICITUD = CType(unaFila.Item(2), String)
                s2.FECHAPROCESO = CType(unaFila.Item(3), String)
                s2.IDMUESTRA = CType(unaFila.Item(4), String)
                s2.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                s2.OBSERVACIONES = CType(unaFila.Item(6), String)
                s2.ESTADOMUESTRA = CType(unaFila.Item(7), String)
                s2.ESTAFCOAGPOSITIVO = CType(unaFila.Item(8), String)
                s2.ESTAFCOAGPOSITIVO_MET = CType(unaFila.Item(9), Integer)
                s2.CF = CType(unaFila.Item(10), String)
                s2.CF_MET = CType(unaFila.Item(11), Integer)
                s2.MOHOS = CType(unaFila.Item(12), String)
                s2.MOHOS_MET = CType(unaFila.Item(13), Integer)
                s2.LEVADURAS = CType(unaFila.Item(14), String)
                s2.LEVADURAS_MET = CType(unaFila.Item(15), Integer)
                s2.CT = CType(unaFila.Item(16), String)
                s2.CT_MET = CType(unaFila.Item(17), Integer)
                s2.ECOLI = CType(unaFila.Item(18), String)
                s2.ECOLI_MET = CType(unaFila.Item(19), Integer)
                s2.ECOLI157 = CType(unaFila.Item(20), String)
                s2.ECOLI157_MET = CType(unaFila.Item(21), Integer)
                s2.SALMONELLA = CType(unaFila.Item(22), Integer)
                s2.SALMONELLA_MET = CType(unaFila.Item(23), Integer)
                s2.LISTERIASPP = CType(unaFila.Item(24), Integer)
                s2.LISTERIASPP_MET = CType(unaFila.Item(25), Integer)
                s2.HUMEDAD = CType(unaFila.Item(26), Double)
                s2.HUMEDAD_MET = CType(unaFila.Item(27), Integer)
                s2.MGRASA = CType(unaFila.Item(28), Double)
                s2.MGRASA_MET = CType(unaFila.Item(29), Integer)
                s2.PH = CType(unaFila.Item(30), Double)
                s2.PH_MET = CType(unaFila.Item(31), Integer)
                s2.CLORUROS = CType(unaFila.Item(32), Double)
                s2.CLORUROS_MET = CType(unaFila.Item(33), Integer)
                s2.PROTEINAS = CType(unaFila.Item(34), Double)
                s2.PROTEINAS_MET = CType(unaFila.Item(35), Integer)
                s2.ENTEROBACTERIAS = CType(unaFila.Item(36), String)
                s2.ENTEROBACTERIAS_MET = CType(unaFila.Item(37), Integer)
                s2.LISTERIAAMBIENTAL = CType(unaFila.Item(38), Integer)
                s2.LISTERIAAMBIENTAL2 = CType(unaFila.Item(39), Integer)
                s2.LISTERIAAMBIENTAL_MET = CType(unaFila.Item(40), Integer)
                s2.ESPORANAERMESOFILO = CType(unaFila.Item(41), Integer)
                s2.ESPORANAERMESOFILO_MET = CType(unaFila.Item(42), Integer)
                s2.TERMOFILOS = CType(unaFila.Item(43), String)
                s2.TERMOFILOS_MET = CType(unaFila.Item(44), Integer)
                s2.PSICROTROFOS = CType(unaFila.Item(45), String)
                s2.PSICROTROFOS_MET = CType(unaFila.Item(46), Integer)
                s2.RB = CType(unaFila.Item(47), String)
                s2.RB_MET = CType(unaFila.Item(48), Integer)
                s2.TABLANUTRICIONAL = CType(unaFila.Item(49), Integer)
                s2.TNPROTEINA = CType(unaFila.Item(50), Double)
                s2.TNCARBOHIDRATOS = CType(unaFila.Item(51), Double)
                s2.TNGRASASTOTALES = CType(unaFila.Item(52), Double)
                s2.TNGRASASSATURADAS = CType(unaFila.Item(53), Double)
                s2.TNGRASASTRANS = CType(unaFila.Item(54), Double)
                s2.LISTERIAMONOCITOGENES = CType(unaFila.Item(55), Integer)
                s2.LISTERIAMONOCITOGENES_MET = CType(unaFila.Item(56), Integer)
                s2.CENIZAS = CType(unaFila.Item(57), Double)
                s2.CENIZAS_MET = CType(unaFila.Item(58), Integer)
                s2.TNSODIO = CType(unaFila.Item(59), Integer)
                s2.TNFIBRAALIMENTICIA = CType(unaFila.Item(60), Integer)
                s2.CODIGOANALITICO = CType(unaFila.Item(61), String)
                s2.TIPOMUESTRA = CType(unaFila.Item(62), Integer)
                s2.OPERADOR = CType(unaFila.Item(63), Integer)
                s2.MARCA = CType(unaFila.Item(64), Integer)
                Return s2
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList

        Dim sql As String = "SELECT id, ficha, fechasolicitud, fechaproceso, idmuestra, detallemuestra, observaciones, estadomuestra, estafcoagpositivo, estafcoagpositivo_met, cf, cf_met, mohos, mohos_met, levaduras, levaduras_met, ct, ct_met, ecoli, ecoli_met,ecoli157, ecoli157_met, salmonella, salmonella_met, listeriaspp, listeriaspp_met, humedad, humedad_met, mgrasa, mgrasa_met, ph, ph_met, cloruros, cloruros_met, proteinas, proteinas_met, enterobacterias, enterobacterias_met, listeriaambiental, listeriaambiental2, listeriaambiental_met, esporanaermesofilo, esporanaer_met, termofilos, termofilos_met, psicrotrofos, psicrotrofos_met, rb,rb_met, tablanutricional, tnproteina,tncarbohidratos, tngrasastotales, tngrasassaturadas, tngrasastrans, listeriamonocitogenes, listeriamono_met, cenizas, cenizas_met, tnsodio, tnfibraalimenticia, ifnull(codigoanalitico,''), tipomuestra, operador, marca FROM subproductos2 WHERE marca = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s2 As New dSubproducto2
                    s2.ID = CType(unaFila.Item(0), Long)
                    s2.FICHA = CType(unaFila.Item(1), Long)
                    s2.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    s2.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s2.IDMUESTRA = CType(unaFila.Item(4), String)
                    s2.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    s2.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s2.ESTADOMUESTRA = CType(unaFila.Item(7), String)
                    s2.ESTAFCOAGPOSITIVO = CType(unaFila.Item(8), String)
                    s2.ESTAFCOAGPOSITIVO_MET = CType(unaFila.Item(9), Integer)
                    s2.CF = CType(unaFila.Item(10), String)
                    s2.CF_MET = CType(unaFila.Item(11), Integer)
                    s2.MOHOS = CType(unaFila.Item(12), String)
                    s2.MOHOS_MET = CType(unaFila.Item(13), Integer)
                    s2.LEVADURAS = CType(unaFila.Item(14), String)
                    s2.LEVADURAS_MET = CType(unaFila.Item(15), Integer)
                    s2.CT = CType(unaFila.Item(16), String)
                    s2.CT_MET = CType(unaFila.Item(17), Integer)
                    s2.ECOLI = CType(unaFila.Item(18), String)
                    s2.ECOLI_MET = CType(unaFila.Item(19), Integer)
                    s2.ECOLI157 = CType(unaFila.Item(20), String)
                    s2.ECOLI157_MET = CType(unaFila.Item(21), Integer)
                    s2.SALMONELLA = CType(unaFila.Item(22), Integer)
                    s2.SALMONELLA_MET = CType(unaFila.Item(23), Integer)
                    s2.LISTERIASPP = CType(unaFila.Item(24), Integer)
                    s2.LISTERIASPP_MET = CType(unaFila.Item(25), Integer)
                    s2.HUMEDAD = CType(unaFila.Item(26), Double)
                    s2.HUMEDAD_MET = CType(unaFila.Item(27), Integer)
                    s2.MGRASA = CType(unaFila.Item(28), Double)
                    s2.MGRASA_MET = CType(unaFila.Item(29), Integer)
                    s2.PH = CType(unaFila.Item(30), Double)
                    s2.PH_MET = CType(unaFila.Item(31), Integer)
                    s2.CLORUROS = CType(unaFila.Item(32), Double)
                    s2.CLORUROS_MET = CType(unaFila.Item(33), Integer)
                    s2.PROTEINAS = CType(unaFila.Item(34), Double)
                    s2.PROTEINAS_MET = CType(unaFila.Item(35), Integer)
                    s2.ENTEROBACTERIAS = CType(unaFila.Item(36), String)
                    s2.ENTEROBACTERIAS_MET = CType(unaFila.Item(37), Integer)
                    s2.LISTERIAAMBIENTAL = CType(unaFila.Item(38), Integer)
                    s2.LISTERIAAMBIENTAL2 = CType(unaFila.Item(39), Integer)
                    s2.LISTERIAAMBIENTAL_MET = CType(unaFila.Item(40), Integer)
                    s2.ESPORANAERMESOFILO = CType(unaFila.Item(41), Integer)
                    s2.ESPORANAERMESOFILO_MET = CType(unaFila.Item(42), Integer)
                    s2.TERMOFILOS = CType(unaFila.Item(43), String)
                    s2.TERMOFILOS_MET = CType(unaFila.Item(44), Integer)
                    s2.PSICROTROFOS = CType(unaFila.Item(45), String)
                    s2.PSICROTROFOS_MET = CType(unaFila.Item(46), Integer)
                    s2.RB = CType(unaFila.Item(47), String)
                    s2.RB_MET = CType(unaFila.Item(48), Integer)
                    s2.TABLANUTRICIONAL = CType(unaFila.Item(49), Integer)
                    s2.TNPROTEINA = CType(unaFila.Item(50), Double)
                    s2.TNCARBOHIDRATOS = CType(unaFila.Item(51), Double)
                    s2.TNGRASASTOTALES = CType(unaFila.Item(52), Double)
                    s2.TNGRASASSATURADAS = CType(unaFila.Item(53), Double)
                    s2.TNGRASASTRANS = CType(unaFila.Item(54), Double)
                    s2.LISTERIAMONOCITOGENES = CType(unaFila.Item(55), Integer)
                    s2.LISTERIAMONOCITOGENES_MET = CType(unaFila.Item(56), Integer)
                    s2.CENIZAS = CType(unaFila.Item(57), Double)
                    s2.CENIZAS_MET = CType(unaFila.Item(58), Integer)
                    s2.TNSODIO = CType(unaFila.Item(59), Integer)
                    s2.TNFIBRAALIMENTICIA = CType(unaFila.Item(60), Integer)
                    s2.CODIGOANALITICO = CType(unaFila.Item(61), String)
                    s2.TIPOMUESTRA = CType(unaFila.Item(62), Integer)
                    s2.OPERADOR = CType(unaFila.Item(63), Integer)
                    s2.MARCA = CType(unaFila.Item(64), Integer)
                    Lista.Add(s2)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM subproductos2 WHERE marca = 0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s2 As New dSubproducto2
                    s2.ficha = CType(unaFila.Item(0), Long)
                    Lista.Add(s2)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = "SELECT id, ficha, fechasolicitud, fechaproceso, idmuestra, detallemuestra, observaciones, estadomuestra, estafcoagpositivo, estafcoagpositivo_met, cf, cf_met, mohos, mohos_met, levaduras, levaduras_met, ct, ct_met, ecoli, ecoli_met,ecoli157, ecoli157_met, salmonella, salmonella_met, listeriaspp, listeriaspp_met, humedad, humedad_met, mgrasa, mgrasa_met, ph, ph_met, cloruros, cloruros_met, proteinas, proteinas_met, enterobacterias, enterobacterias_met, listeriaambiental, listeriaambiental2, listeriaambiental_met, esporanaermesofilo, esporanaer_met, termofilos, termofilos_met, psicrotrofos, psicrotrofos_met, rb,rb_met, tablanutricional, tnproteina,tncarbohidratos, tngrasastotales, tngrasassaturadas, tngrasastrans, listeriamonocitogenes, listeriamono_met, cenizas, cenizas_met, tnsodio, tnfibraalimenticia, ifnull(codigoanalitico,''), tipomuestra, operador, marca FROM subproductos2 where ficha = " & texto
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(Sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s2 As New dSubproducto2
                    s2.ID = CType(unaFila.Item(0), Long)
                    s2.FICHA = CType(unaFila.Item(1), Long)
                    s2.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    s2.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s2.IDMUESTRA = CType(unaFila.Item(4), String)
                    s2.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    s2.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s2.ESTADOMUESTRA = CType(unaFila.Item(7), String)
                    s2.ESTAFCOAGPOSITIVO = CType(unaFila.Item(8), String)
                    s2.ESTAFCOAGPOSITIVO_MET = CType(unaFila.Item(9), Integer)
                    s2.CF = CType(unaFila.Item(10), String)
                    s2.CF_MET = CType(unaFila.Item(11), Integer)
                    s2.MOHOS = CType(unaFila.Item(12), String)
                    s2.MOHOS_MET = CType(unaFila.Item(13), Integer)
                    s2.LEVADURAS = CType(unaFila.Item(14), String)
                    s2.LEVADURAS_MET = CType(unaFila.Item(15), Integer)
                    s2.CT = CType(unaFila.Item(16), String)
                    s2.CT_MET = CType(unaFila.Item(17), Integer)
                    s2.ECOLI = CType(unaFila.Item(18), String)
                    s2.ECOLI_MET = CType(unaFila.Item(19), Integer)
                    s2.ECOLI157 = CType(unaFila.Item(20), String)
                    s2.ECOLI157_MET = CType(unaFila.Item(21), Integer)
                    s2.SALMONELLA = CType(unaFila.Item(22), Integer)
                    s2.SALMONELLA_MET = CType(unaFila.Item(23), Integer)
                    s2.LISTERIASPP = CType(unaFila.Item(24), Integer)
                    s2.LISTERIASPP_MET = CType(unaFila.Item(25), Integer)
                    s2.HUMEDAD = CType(unaFila.Item(26), Double)
                    s2.HUMEDAD_MET = CType(unaFila.Item(27), Integer)
                    s2.MGRASA = CType(unaFila.Item(28), Double)
                    s2.MGRASA_MET = CType(unaFila.Item(29), Integer)
                    s2.PH = CType(unaFila.Item(30), Double)
                    s2.PH_MET = CType(unaFila.Item(31), Integer)
                    s2.CLORUROS = CType(unaFila.Item(32), Double)
                    s2.CLORUROS_MET = CType(unaFila.Item(33), Integer)
                    s2.PROTEINAS = CType(unaFila.Item(34), Double)
                    s2.PROTEINAS_MET = CType(unaFila.Item(35), Integer)
                    s2.ENTEROBACTERIAS = CType(unaFila.Item(36), String)
                    s2.ENTEROBACTERIAS_MET = CType(unaFila.Item(37), Integer)
                    s2.LISTERIAAMBIENTAL = CType(unaFila.Item(38), Integer)
                    s2.LISTERIAAMBIENTAL2 = CType(unaFila.Item(39), Integer)
                    s2.LISTERIAAMBIENTAL_MET = CType(unaFila.Item(40), Integer)
                    s2.ESPORANAERMESOFILO = CType(unaFila.Item(41), Integer)
                    s2.ESPORANAERMESOFILO_MET = CType(unaFila.Item(42), Integer)
                    s2.TERMOFILOS = CType(unaFila.Item(43), String)
                    s2.TERMOFILOS_MET = CType(unaFila.Item(44), Integer)
                    s2.PSICROTROFOS = CType(unaFila.Item(45), String)
                    s2.PSICROTROFOS_MET = CType(unaFila.Item(46), Integer)
                    s2.RB = CType(unaFila.Item(47), String)
                    s2.RB_MET = CType(unaFila.Item(48), Integer)
                    s2.TABLANUTRICIONAL = CType(unaFila.Item(49), Integer)
                    s2.TNPROTEINA = CType(unaFila.Item(50), Double)
                    s2.TNCARBOHIDRATOS = CType(unaFila.Item(51), Double)
                    s2.TNGRASASTOTALES = CType(unaFila.Item(52), Double)
                    s2.TNGRASASSATURADAS = CType(unaFila.Item(53), Double)
                    s2.TNGRASASTRANS = CType(unaFila.Item(54), Double)
                    s2.LISTERIAMONOCITOGENES = CType(unaFila.Item(55), Integer)
                    s2.LISTERIAMONOCITOGENES_MET = CType(unaFila.Item(56), Integer)
                    s2.CENIZAS = CType(unaFila.Item(57), Double)
                    s2.CENIZAS_MET = CType(unaFila.Item(58), Integer)
                    s2.TNSODIO = CType(unaFila.Item(59), Integer)
                    s2.TNFIBRAALIMENTICIA = CType(unaFila.Item(60), Integer)
                    s2.CODIGOANALITICO = CType(unaFila.Item(61), String)
                    s2.TIPOMUESTRA = CType(unaFila.Item(62), Integer)
                    s2.OPERADOR = CType(unaFila.Item(63), Integer)
                    s2.MARCA = CType(unaFila.Item(64), Integer)
                    Lista.Add(s2)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idmuestra, detallemuestra, observaciones, estadomuestra, estafcoagpositivo, estafcoagpositivo_met, cf, cf_met, mohos, mohos_met, levaduras, levaduras_met, ct, ct_met, ecoli, ecoli_met,ecoli157, ecoli157_met, salmonella, salmonella_met, listeriaspp, listeriaspp_met, humedad, humedad_met, mgrasa, mgrasa_met, ph, ph_met, cloruros, cloruros_met, proteinas, proteinas_met, enterobacterias, enterobacterias_met, listeriaambiental, listeriaambiental2, listeriaambiental_met, esporanaermesofilo, esporanaer_met, termofilos, termofilos_met, psicrotrofos, psicrotrofos_met, rb,rb_met, tablanutricional, tnproteina,tncarbohidratos, tngrasastotales, tngrasassaturadas, tngrasastrans, listeriamonocitogenes, listeriamono_met, cenizas, cenizas_met, tnsodio, tnfibraalimenticia, ifnull(codigoanalitico,''), tipomuestra, operador, marca FROM subproductos2 where marca = 0 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s2 As New dSubproducto2
                    s2.ID = CType(unaFila.Item(0), Long)
                    s2.FICHA = CType(unaFila.Item(1), Long)
                    s2.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    s2.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s2.IDMUESTRA = CType(unaFila.Item(4), String)
                    s2.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    s2.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s2.ESTADOMUESTRA = CType(unaFila.Item(7), String)
                    s2.ESTAFCOAGPOSITIVO = CType(unaFila.Item(8), String)
                    s2.ESTAFCOAGPOSITIVO_MET = CType(unaFila.Item(9), Integer)
                    s2.CF = CType(unaFila.Item(10), String)
                    s2.CF_MET = CType(unaFila.Item(11), Integer)
                    s2.MOHOS = CType(unaFila.Item(12), String)
                    s2.MOHOS_MET = CType(unaFila.Item(13), Integer)
                    s2.LEVADURAS = CType(unaFila.Item(14), String)
                    s2.LEVADURAS_MET = CType(unaFila.Item(15), Integer)
                    s2.CT = CType(unaFila.Item(16), String)
                    s2.CT_MET = CType(unaFila.Item(17), Integer)
                    s2.ECOLI = CType(unaFila.Item(18), String)
                    s2.ECOLI_MET = CType(unaFila.Item(19), Integer)
                    s2.ECOLI157 = CType(unaFila.Item(20), String)
                    s2.ECOLI157_MET = CType(unaFila.Item(21), Integer)
                    s2.SALMONELLA = CType(unaFila.Item(22), Integer)
                    s2.SALMONELLA_MET = CType(unaFila.Item(23), Integer)
                    s2.LISTERIASPP = CType(unaFila.Item(24), Integer)
                    s2.LISTERIASPP_MET = CType(unaFila.Item(25), Integer)
                    s2.HUMEDAD = CType(unaFila.Item(26), Double)
                    s2.HUMEDAD_MET = CType(unaFila.Item(27), Integer)
                    s2.MGRASA = CType(unaFila.Item(28), Double)
                    s2.MGRASA_MET = CType(unaFila.Item(29), Integer)
                    s2.PH = CType(unaFila.Item(30), Double)
                    s2.PH_MET = CType(unaFila.Item(31), Integer)
                    s2.CLORUROS = CType(unaFila.Item(32), Double)
                    s2.CLORUROS_MET = CType(unaFila.Item(33), Integer)
                    s2.PROTEINAS = CType(unaFila.Item(34), Double)
                    s2.PROTEINAS_MET = CType(unaFila.Item(35), Integer)
                    s2.ENTEROBACTERIAS = CType(unaFila.Item(36), String)
                    s2.ENTEROBACTERIAS_MET = CType(unaFila.Item(37), Integer)
                    s2.LISTERIAAMBIENTAL = CType(unaFila.Item(38), Integer)
                    s2.LISTERIAAMBIENTAL2 = CType(unaFila.Item(39), Integer)
                    s2.LISTERIAAMBIENTAL_MET = CType(unaFila.Item(40), Integer)
                    s2.ESPORANAERMESOFILO = CType(unaFila.Item(41), Integer)
                    s2.ESPORANAERMESOFILO_MET = CType(unaFila.Item(42), Integer)
                    s2.TERMOFILOS = CType(unaFila.Item(43), String)
                    s2.TERMOFILOS_MET = CType(unaFila.Item(44), Integer)
                    s2.PSICROTROFOS = CType(unaFila.Item(45), String)
                    s2.PSICROTROFOS_MET = CType(unaFila.Item(46), Integer)
                    s2.RB = CType(unaFila.Item(47), String)
                    s2.RB_MET = CType(unaFila.Item(48), Integer)
                    s2.TABLANUTRICIONAL = CType(unaFila.Item(49), Integer)
                    s2.TNPROTEINA = CType(unaFila.Item(50), Double)
                    s2.TNCARBOHIDRATOS = CType(unaFila.Item(51), Double)
                    s2.TNGRASASTOTALES = CType(unaFila.Item(52), Double)
                    s2.TNGRASASSATURADAS = CType(unaFila.Item(53), Double)
                    s2.TNGRASASTRANS = CType(unaFila.Item(54), Double)
                    s2.LISTERIAMONOCITOGENES = CType(unaFila.Item(55), Integer)
                    s2.LISTERIAMONOCITOGENES_MET = CType(unaFila.Item(56), Integer)
                    s2.CENIZAS = CType(unaFila.Item(57), Double)
                    s2.CENIZAS_MET = CType(unaFila.Item(58), Integer)
                    s2.TNSODIO = CType(unaFila.Item(59), Integer)
                    s2.TNFIBRAALIMENTICIA = CType(unaFila.Item(60), Integer)
                    s2.CODIGOANALITICO = CType(unaFila.Item(61), String)
                    s2.TIPOMUESTRA = CType(unaFila.Item(62), Integer)
                    s2.OPERADOR = CType(unaFila.Item(63), Integer)
                    s2.MARCA = CType(unaFila.Item(64), Integer)
                    Lista.Add(s2)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idmuestra, detallemuestra, observaciones, estadomuestra, estafcoagpositivo, estafcoagpositivo_met, cf, cf_met, mohos, mohos_met, levaduras, levaduras_met, ct, ct_met, ecoli, ecoli_met,ecoli157, ecoli157_met, salmonella, salmonella_met, listeriaspp, listeriaspp_met, humedad, humedad_met, mgrasa, mgrasa_met, ph, ph_met, cloruros, cloruros_met, proteinas, proteinas_met, enterobacterias, enterobacterias_met, listeriaambiental, listeriaambiental2, listeriaambiental_met, esporanaermesofilo, esporanaer_met, termofilos, termofilos_met, psicrotrofos, psicrotrofos_met, rb,rb_met, tablanutricional, tnproteina,tncarbohidratos, tngrasastotales, tngrasassaturadas, tngrasastrans, listeriamonocitogenes, listeriamono_met, cenizas, cenizas_met, tnsodio, tnfibraalimenticia, ifnull(codigoanalitico,''), tipomuestra, operador, marca FROM subproductos2 where marca = 1 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(Sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s2 As New dSubproducto2
                    s2.ID = CType(unaFila.Item(0), Long)
                    s2.FICHA = CType(unaFila.Item(1), Long)
                    s2.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    s2.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s2.IDMUESTRA = CType(unaFila.Item(4), String)
                    s2.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    s2.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s2.ESTADOMUESTRA = CType(unaFila.Item(7), String)
                    s2.ESTAFCOAGPOSITIVO = CType(unaFila.Item(8), String)
                    s2.ESTAFCOAGPOSITIVO_MET = CType(unaFila.Item(9), Integer)
                    s2.CF = CType(unaFila.Item(10), String)
                    s2.CF_MET = CType(unaFila.Item(11), Integer)
                    s2.MOHOS = CType(unaFila.Item(12), String)
                    s2.MOHOS_MET = CType(unaFila.Item(13), Integer)
                    s2.LEVADURAS = CType(unaFila.Item(14), String)
                    s2.LEVADURAS_MET = CType(unaFila.Item(15), Integer)
                    s2.CT = CType(unaFila.Item(16), String)
                    s2.CT_MET = CType(unaFila.Item(17), Integer)
                    s2.ECOLI = CType(unaFila.Item(18), String)
                    s2.ECOLI_MET = CType(unaFila.Item(19), Integer)
                    s2.ECOLI157 = CType(unaFila.Item(20), String)
                    s2.ECOLI157_MET = CType(unaFila.Item(21), Integer)
                    s2.SALMONELLA = CType(unaFila.Item(22), Integer)
                    s2.SALMONELLA_MET = CType(unaFila.Item(23), Integer)
                    s2.LISTERIASPP = CType(unaFila.Item(24), Integer)
                    s2.LISTERIASPP_MET = CType(unaFila.Item(25), Integer)
                    s2.HUMEDAD = CType(unaFila.Item(26), Double)
                    s2.HUMEDAD_MET = CType(unaFila.Item(27), Integer)
                    s2.MGRASA = CType(unaFila.Item(28), Double)
                    s2.MGRASA_MET = CType(unaFila.Item(29), Integer)
                    s2.PH = CType(unaFila.Item(30), Double)
                    s2.PH_MET = CType(unaFila.Item(31), Integer)
                    s2.CLORUROS = CType(unaFila.Item(32), Double)
                    s2.CLORUROS_MET = CType(unaFila.Item(33), Integer)
                    s2.PROTEINAS = CType(unaFila.Item(34), Double)
                    s2.PROTEINAS_MET = CType(unaFila.Item(35), Integer)
                    s2.ENTEROBACTERIAS = CType(unaFila.Item(36), String)
                    s2.ENTEROBACTERIAS_MET = CType(unaFila.Item(37), Integer)
                    s2.LISTERIAAMBIENTAL = CType(unaFila.Item(38), Integer)
                    s2.LISTERIAAMBIENTAL2 = CType(unaFila.Item(39), Integer)
                    s2.LISTERIAAMBIENTAL_MET = CType(unaFila.Item(40), Integer)
                    s2.ESPORANAERMESOFILO = CType(unaFila.Item(41), Integer)
                    s2.ESPORANAERMESOFILO_MET = CType(unaFila.Item(42), Integer)
                    s2.TERMOFILOS = CType(unaFila.Item(43), String)
                    s2.TERMOFILOS_MET = CType(unaFila.Item(44), Integer)
                    s2.PSICROTROFOS = CType(unaFila.Item(45), String)
                    s2.PSICROTROFOS_MET = CType(unaFila.Item(46), Integer)
                    s2.RB = CType(unaFila.Item(47), String)
                    s2.RB_MET = CType(unaFila.Item(48), Integer)
                    s2.TABLANUTRICIONAL = CType(unaFila.Item(49), Integer)
                    s2.TNPROTEINA = CType(unaFila.Item(50), Double)
                    s2.TNCARBOHIDRATOS = CType(unaFila.Item(51), Double)
                    s2.TNGRASASTOTALES = CType(unaFila.Item(52), Double)
                    s2.TNGRASASSATURADAS = CType(unaFila.Item(53), Double)
                    s2.TNGRASASTRANS = CType(unaFila.Item(54), Double)
                    s2.LISTERIAMONOCITOGENES = CType(unaFila.Item(55), Integer)
                    s2.LISTERIAMONOCITOGENES_MET = CType(unaFila.Item(56), Integer)
                    s2.CENIZAS = CType(unaFila.Item(57), Double)
                    s2.CENIZAS_MET = CType(unaFila.Item(58), Integer)
                    s2.TNSODIO = CType(unaFila.Item(59), Integer)
                    s2.TNFIBRAALIMENTICIA = CType(unaFila.Item(60), Integer)
                    s2.CODIGOANALITICO = CType(unaFila.Item(61), String)
                    s2.TIPOMUESTRA = CType(unaFila.Item(62), Integer)
                    s2.OPERADOR = CType(unaFila.Item(63), Integer)
                    s2.MARCA = CType(unaFila.Item(64), Integer)
                    Lista.Add(s2)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idmuestra, detallemuestra, observaciones, estadomuestra, estafcoagpositivo, estafcoagpositivo_met, cf, cf_met, mohos, mohos_met, levaduras, levaduras_met, ct, ct_met, ecoli, ecoli_met,ecoli157, ecoli157_met, salmonella, salmonella_met, listeriaspp, listeriaspp_met, humedad, humedad_met, mgrasa, mgrasa_met, ph, ph_met, cloruros, cloruros_met, proteinas, proteinas_met, enterobacterias, enterobacterias_met, listeriaambiental, listeriaambiental2, listeriaambiental_met, esporanaermesofilo, esporanaer_met, termofilos, termofilos_met, psicrotrofos, psicrotrofos_met, rb,rb_met, tablanutricional, tnproteina,tncarbohidratos, tngrasastotales, tngrasassaturadas, tngrasastrans, listeriamonocitogenes, listeriamono_met, cenizas, cenizas_met, tnsodio, tnfibraalimenticia, ifnull(codigoanalitico,''), tipomuestra, operador, marca FROM subproductos2 where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s2 As New dSubproducto2
                    s2.ID = CType(unaFila.Item(0), Long)
                    s2.FICHA = CType(unaFila.Item(1), Long)
                    s2.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    s2.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s2.IDMUESTRA = CType(unaFila.Item(4), String)
                    s2.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    s2.OBSERVACIONES = CType(unaFila.Item(6), String)
                    s2.ESTADOMUESTRA = CType(unaFila.Item(7), String)
                    s2.ESTAFCOAGPOSITIVO = CType(unaFila.Item(8), String)
                    s2.ESTAFCOAGPOSITIVO_MET = CType(unaFila.Item(9), Integer)
                    s2.CF = CType(unaFila.Item(10), String)
                    s2.CF_MET = CType(unaFila.Item(11), Integer)
                    s2.MOHOS = CType(unaFila.Item(12), String)
                    s2.MOHOS_MET = CType(unaFila.Item(13), Integer)
                    s2.LEVADURAS = CType(unaFila.Item(14), String)
                    s2.LEVADURAS_MET = CType(unaFila.Item(15), Integer)
                    s2.CT = CType(unaFila.Item(16), String)
                    s2.CT_MET = CType(unaFila.Item(17), Integer)
                    s2.ECOLI = CType(unaFila.Item(18), String)
                    s2.ECOLI_MET = CType(unaFila.Item(19), Integer)
                    s2.ECOLI157 = CType(unaFila.Item(20), String)
                    s2.ECOLI157_MET = CType(unaFila.Item(21), Integer)
                    s2.SALMONELLA = CType(unaFila.Item(22), Integer)
                    s2.SALMONELLA_MET = CType(unaFila.Item(23), Integer)
                    s2.LISTERIASPP = CType(unaFila.Item(24), Integer)
                    s2.LISTERIASPP_MET = CType(unaFila.Item(25), Integer)
                    s2.HUMEDAD = CType(unaFila.Item(26), Double)
                    s2.HUMEDAD_MET = CType(unaFila.Item(27), Integer)
                    s2.MGRASA = CType(unaFila.Item(28), Double)
                    s2.MGRASA_MET = CType(unaFila.Item(29), Integer)
                    s2.PH = CType(unaFila.Item(30), Double)
                    s2.PH_MET = CType(unaFila.Item(31), Integer)
                    s2.CLORUROS = CType(unaFila.Item(32), Double)
                    s2.CLORUROS_MET = CType(unaFila.Item(33), Integer)
                    s2.PROTEINAS = CType(unaFila.Item(34), Double)
                    s2.PROTEINAS_MET = CType(unaFila.Item(35), Integer)
                    s2.ENTEROBACTERIAS = CType(unaFila.Item(36), String)
                    s2.ENTEROBACTERIAS_MET = CType(unaFila.Item(37), Integer)
                    s2.LISTERIAAMBIENTAL = CType(unaFila.Item(38), Integer)
                    s2.LISTERIAAMBIENTAL2 = CType(unaFila.Item(39), Integer)
                    s2.LISTERIAAMBIENTAL_MET = CType(unaFila.Item(40), Integer)
                    s2.ESPORANAERMESOFILO = CType(unaFila.Item(41), Integer)
                    s2.ESPORANAERMESOFILO_MET = CType(unaFila.Item(42), Integer)
                    s2.TERMOFILOS = CType(unaFila.Item(43), String)
                    s2.TERMOFILOS_MET = CType(unaFila.Item(44), Integer)
                    s2.PSICROTROFOS = CType(unaFila.Item(45), String)
                    s2.PSICROTROFOS_MET = CType(unaFila.Item(46), Integer)
                    s2.RB = CType(unaFila.Item(47), String)
                    s2.RB_MET = CType(unaFila.Item(48), Integer)
                    s2.TABLANUTRICIONAL = CType(unaFila.Item(49), Integer)
                    s2.TNPROTEINA = CType(unaFila.Item(50), Double)
                    s2.TNCARBOHIDRATOS = CType(unaFila.Item(51), Double)
                    s2.TNGRASASTOTALES = CType(unaFila.Item(52), Double)
                    s2.TNGRASASSATURADAS = CType(unaFila.Item(53), Double)
                    s2.TNGRASASTRANS = CType(unaFila.Item(54), Double)
                    s2.LISTERIAMONOCITOGENES = CType(unaFila.Item(55), Integer)
                    s2.LISTERIAMONOCITOGENES_MET = CType(unaFila.Item(56), Integer)
                    s2.CENIZAS = CType(unaFila.Item(57), Double)
                    s2.CENIZAS_MET = CType(unaFila.Item(58), Integer)
                    s2.TNSODIO = CType(unaFila.Item(59), Integer)
                    s2.TNFIBRAALIMENTICIA = CType(unaFila.Item(60), Integer)
                    s2.CODIGOANALITICO = CType(unaFila.Item(61), String)
                    s2.TIPOMUESTRA = CType(unaFila.Item(62), Integer)
                    s2.OPERADOR = CType(unaFila.Item(63), Integer)
                    s2.MARCA = CType(unaFila.Item(64), Integer)
                    Lista.Add(s2)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
