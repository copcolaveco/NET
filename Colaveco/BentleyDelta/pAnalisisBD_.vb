Public Class pAnalisisBD_
    Inherits Conectoras.ConexionMySQL_BentleyDelta
    Public Function vaciar(ByVal o As Object, ByVal usuario As dUsuario, ByVal arch As String) As Boolean
        Dim obj As dAnalisisBD_ = CType(o, dAnalisisBD_)
        Dim sql As String = "DELETE FROM analisis where archivo = '" & arch & "'"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
   
    Public Function buscar(ByVal o As Object) As dAnalisisBD_
        Dim obj As dAnalisisBD_ = CType(o, dAnalisisBD_)
        Dim l As New dAnalisisBD_
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT codigo, ident, fecha, hora, id,  grasa, proteina, lactosa, soltotales, celulas, crioscopia, urea, equipo, vmgrasa, vmproteina, vmlactosa, vmstotales, vmcelulas, vmcrioscopia, vmurea, archivo, fila FROM analisis WHERE codigo = " & obj.CODIGO & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.CODIGO = CType(unaFila.Item(0), Long)
                l.IDENT = CType(unaFila.Item(1), Long)
                l.FECHA = CType(unaFila.Item(2), String)
                l.HORA = CType(unaFila.Item(3), String)
                l.ID = CType(unaFila.Item(4), Double)
                l.GRASA = CType(unaFila.Item(5), Double)
                l.PROTEINA = CType(unaFila.Item(6), Double)
                l.LACTOSA = CType(unaFila.Item(7), Double)
                l.SOLTOTALES = CType(unaFila.Item(8), Double)
                l.CELULAS = CType(unaFila.Item(9), Long)
                l.CRIOSCOPIA = CType(unaFila.Item(10), Long)
                l.UREA = CType(unaFila.Item(11), Integer)
                l.EQUIPO = CType(unaFila.Item(12), String)
                l.VMGRASA = CType(unaFila.Item(13), Double)
                l.VMPROTEINA = CType(unaFila.Item(14), Double)
                l.VMLACTOSA = CType(unaFila.Item(15), Double)
                l.VMSTOTALES = CType(unaFila.Item(16), Double)
                l.VMCELULAS = CType(unaFila.Item(17), Double)
                l.VMCRIOSCOPIA = CType(unaFila.Item(18), Double)
                l.VMUREA = CType(unaFila.Item(19), Double)
                l.ARCHIVO = CType(unaFila.Item(20), String)
                l.FILA = CType(unaFila.Item(21), Long)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxarchivo(ByVal o As Object) As dAnalisisBD_
        Dim obj As dAnalisisBD_ = CType(o, dAnalisisBD_)
        Dim l As New dAnalisisBD_
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT codigo, ident, fecha, hora, id,  grasa, proteina, lactosa, soltotales, celulas, crioscopia, urea, equipo, vmgrasa, vmproteina, vmlactosa, vmstotales, vmcelulas, vmcrioscopia, vmurea, archivo, fila FROM analisis WHERE archivo = '" & obj.ARCHIVO & "' order by codigo desc LIMIT 1")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.CODIGO = CType(unaFila.Item(0), Long)
                l.IDENT = CType(unaFila.Item(1), Long)
                l.FECHA = CType(unaFila.Item(2), String)
                l.HORA = CType(unaFila.Item(3), String)
                l.ID = CType(unaFila.Item(4), Double)
                l.GRASA = CType(unaFila.Item(5), Double)
                l.PROTEINA = CType(unaFila.Item(6), Double)
                l.LACTOSA = CType(unaFila.Item(7), Double)
                l.SOLTOTALES = CType(unaFila.Item(8), Double)
                l.CELULAS = CType(unaFila.Item(9), Long)
                l.CRIOSCOPIA = CType(unaFila.Item(10), Long)
                l.UREA = CType(unaFila.Item(11), Integer)
                l.EQUIPO = CType(unaFila.Item(12), String)
                l.VMGRASA = CType(unaFila.Item(13), Double)
                l.VMPROTEINA = CType(unaFila.Item(14), Double)
                l.VMLACTOSA = CType(unaFila.Item(15), Double)
                l.VMSTOTALES = CType(unaFila.Item(16), Double)
                l.VMCELULAS = CType(unaFila.Item(17), Double)
                l.VMCRIOSCOPIA = CType(unaFila.Item(18), Double)
                l.VMUREA = CType(unaFila.Item(19), Double)
                l.ARCHIVO = CType(unaFila.Item(20), String)
                l.FILA = CType(unaFila.Item(21), Long)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT codigo, ident, fecha, hora, id, grasa, proteina, lactosa, soltotales, celulas, crioscopia, urea, equipo, vmgrasa, vmproteina, vmlactosa, vmstotales, vmcelulas, vmcrioscopia, vmurea, archivo, fila FROM analisis"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAnalisisBD_
                    l.CODIGO = CType(unaFila.Item(0), Long)
                    l.IDENT = CType(unaFila.Item(1), Long)
                    l.FECHA = CType(unaFila.Item(2), String)
                    l.HORA = CType(unaFila.Item(3), String)
                    l.ID = CType(unaFila.Item(4), Double)
                    l.GRASA = CType(unaFila.Item(5), Double)
                    l.PROTEINA = CType(unaFila.Item(6), Double)
                    l.LACTOSA = CType(unaFila.Item(7), Double)
                    l.SOLTOTALES = CType(unaFila.Item(8), Double)
                    l.CELULAS = CType(unaFila.Item(9), Long)
                    l.CRIOSCOPIA = CType(unaFila.Item(10), Long)
                    l.UREA = CType(unaFila.Item(11), Integer)
                    l.EQUIPO = CType(unaFila.Item(12), String)
                    l.VMGRASA = CType(unaFila.Item(13), Double)
                    l.VMPROTEINA = CType(unaFila.Item(14), Double)
                    l.VMLACTOSA = CType(unaFila.Item(15), Double)
                    l.VMSTOTALES = CType(unaFila.Item(16), Double)
                    l.VMCELULAS = CType(unaFila.Item(17), Double)
                    l.VMCRIOSCOPIA = CType(unaFila.Item(18), Double)
                    l.VMUREA = CType(unaFila.Item(19), Double)
                    l.ARCHIVO = CType(unaFila.Item(20), String)
                    l.FILA = CType(unaFila.Item(21), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar1(ByVal arch As String) As ArrayList
        Dim sql As String = "SELECT codigo, ident, fecha, hora, id, grasa, proteina, lactosa, soltotales, celulas, crioscopia, urea, equipo, vmgrasa, vmproteina, vmlactosa, vmstotales, vmcelulas, vmcrioscopia, vmurea, archivo, fila FROM analisis WHERE ident = 1 and archivo = '" & arch & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAnalisisBD_
                    l.CODIGO = CType(unaFila.Item(0), Long)
                    l.IDENT = CType(unaFila.Item(1), Long)
                    l.FECHA = CType(unaFila.Item(2), String)
                    l.HORA = CType(unaFila.Item(3), String)
                    l.ID = CType(unaFila.Item(4), Double)
                    l.GRASA = CType(unaFila.Item(5), Double)
                    l.PROTEINA = CType(unaFila.Item(6), Double)
                    l.LACTOSA = CType(unaFila.Item(7), Double)
                    l.SOLTOTALES = CType(unaFila.Item(8), Double)
                    l.CELULAS = CType(unaFila.Item(9), Long)
                    l.CRIOSCOPIA = CType(unaFila.Item(10), Long)
                    l.UREA = CType(unaFila.Item(11), Integer)
                    l.EQUIPO = CType(unaFila.Item(12), String)
                    l.VMGRASA = CType(unaFila.Item(13), Double)
                    l.VMPROTEINA = CType(unaFila.Item(14), Double)
                    l.VMLACTOSA = CType(unaFila.Item(15), Double)
                    l.VMSTOTALES = CType(unaFila.Item(16), Double)
                    l.VMCELULAS = CType(unaFila.Item(17), Double)
                    l.VMCRIOSCOPIA = CType(unaFila.Item(18), Double)
                    l.VMUREA = CType(unaFila.Item(19), Double)
                    l.ARCHIVO = CType(unaFila.Item(20), String)
                    l.FILA = CType(unaFila.Item(21), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar2(ByVal arch As String) As ArrayList
        Dim sql As String = "SELECT codigo, ident, fecha, hora, id, grasa, proteina, lactosa, soltotales, celulas, crioscopia, urea, equipo, vmgrasa, vmproteina, vmlactosa, vmstotales, vmcelulas, vmcrioscopia, vmurea, archivo, fila FROM analisis WHERE ident = 2 and archivo = '" & arch & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAnalisisBD_
                    l.CODIGO = CType(unaFila.Item(0), Long)
                    l.IDENT = CType(unaFila.Item(1), Long)
                    l.FECHA = CType(unaFila.Item(2), String)
                    l.HORA = CType(unaFila.Item(3), String)
                    l.ID = CType(unaFila.Item(4), Double)
                    l.GRASA = CType(unaFila.Item(5), Double)
                    l.PROTEINA = CType(unaFila.Item(6), Double)
                    l.LACTOSA = CType(unaFila.Item(7), Double)
                    l.SOLTOTALES = CType(unaFila.Item(8), Double)
                    l.CELULAS = CType(unaFila.Item(9), Long)
                    l.CRIOSCOPIA = CType(unaFila.Item(10), Long)
                    l.UREA = CType(unaFila.Item(11), Integer)
                    l.EQUIPO = CType(unaFila.Item(12), String)
                    l.VMGRASA = CType(unaFila.Item(13), Double)
                    l.VMPROTEINA = CType(unaFila.Item(14), Double)
                    l.VMLACTOSA = CType(unaFila.Item(15), Double)
                    l.VMSTOTALES = CType(unaFila.Item(16), Double)
                    l.VMCELULAS = CType(unaFila.Item(17), Double)
                    l.VMCRIOSCOPIA = CType(unaFila.Item(18), Double)
                    l.VMUREA = CType(unaFila.Item(19), Double)
                    l.ARCHIVO = CType(unaFila.Item(20), String)
                    l.FILA = CType(unaFila.Item(21), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
    Public Function listarxarchivo(ByVal arch As String) As ArrayList
        Dim sql As String = "SELECT codigo, ident, fecha, hora, id, grasa, proteina, lactosa, soltotales, celulas, crioscopia, urea, equipo, vmgrasa, vmproteina, vmlactosa, vmstotales, vmcelulas, vmcrioscopia, vmurea, archivo, fila FROM analisis WHERE archivo = '" & arch & "' ORDER BY fila ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAnalisisBD_
                    l.CODIGO = CType(unaFila.Item(0), Long)
                    l.IDENT = CType(unaFila.Item(1), Long)
                    l.FECHA = CType(unaFila.Item(2), String)
                    l.HORA = CType(unaFila.Item(3), String)
                    l.ID = CType(unaFila.Item(4), Double)
                    l.GRASA = CType(unaFila.Item(5), Double)
                    l.PROTEINA = CType(unaFila.Item(6), Double)
                    l.LACTOSA = CType(unaFila.Item(7), Double)
                    l.SOLTOTALES = CType(unaFila.Item(8), Double)
                    l.CELULAS = CType(unaFila.Item(9), Long)
                    l.CRIOSCOPIA = CType(unaFila.Item(10), Long)
                    l.UREA = CType(unaFila.Item(11), Integer)
                    l.EQUIPO = CType(unaFila.Item(12), String)
                    l.VMGRASA = CType(unaFila.Item(13), Double)
                    l.VMPROTEINA = CType(unaFila.Item(14), Double)
                    l.VMLACTOSA = CType(unaFila.Item(15), Double)
                    l.VMSTOTALES = CType(unaFila.Item(16), Double)
                    l.VMCELULAS = CType(unaFila.Item(17), Double)
                    l.VMCRIOSCOPIA = CType(unaFila.Item(18), Double)
                    l.VMUREA = CType(unaFila.Item(19), Double)
                    l.ARCHIVO = CType(unaFila.Item(20), String)
                    l.FILA = CType(unaFila.Item(21), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
