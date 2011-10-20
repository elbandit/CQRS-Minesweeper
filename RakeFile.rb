require 'rake'
require 'albacore'
require 'configatron'

task :default => [:msbuild]

task :core_specs => [:msbuild, :run_mspec]

task :uat_specs => [:msbuild, :uat, :specflow_report]

task :run_migrations => [:migrations]

desc "Building solution"
msbuild do |msb|      
    
  msb.properties :configuration => :Release
  msb.targets :Clean, :Build
  msb.verbosity = 'quiet'
  msb.solution = "Columbo.Minesweeper.sln"  
end

desc "Database Migrations"
task :migrations do
    	
	##connection_string = ".\\SQLEXPRESS"
	connection_string = "."
	sql_files_directory = ".\\db"

	sh "./Tools/RoundhousE.v0.7.0.281/rh.exe /d=Minesweeper /s=" + connection_string + " /f=" + sql_files_directory	
end

desc "Run Machine.Specifications"
mspec :run_mspec do |runner|
	##runner.log_level = log_level
	runner.command = './packages/Machine.Specifications.0.4.24.0/tools/mspec-clr4.exe'
	##runner.html_output = './Artefacts/SpecResults/index.html'
	runner.assemblies << "./Columbo.Minesweeper.Specs.Core/bin/Release/Columbo.Minesweeper.Specs.Core.dll"
	##runner.parameters = '--teamcity'
end

desc "NUnit Running UAT"
nunit :uat do |nunit|
	nunit.command = "./packages/NUnit.2.5.10.11092/tools/nunit-console.exe"
	nunit.assemblies "./Columbo.Minesweeper.Specs.Uat/bin/Release/Columbo.Minesweeper.Specs.Uat.dll"
end

specflowreport :specflow_report do |sfr|
  sfr.command = "./packages/SpecFlow.1.7.1/tools/specflow.exe"
  sfr.projects "./Columbo.Minesweeper.Specs.Uat/Columbo.Minesweeper.Specs.Uat.csproj"
  ##sfr.reports "nunitexecutionreport"
  sfr.options "/out:specs.html"
end

desc 'Update assembly info'
assemblyinfo :update_version do |asm|
	asm.output_file = 'Columbo.Minesweeper.Ui.Web/Properties/AssemblyInfo.cs'

	asm.version = "1.2.1.2"
	asm.company_name = 'Columbo Inc.'
	asm.product_name = 'Minesweeper'
	asm.copyright = 'Copyright Columbo Inc. All rights reserved'
end

task :set_environment_variables do
	$env = ENV['environment']	
	if $env.nil? 
		puts "Please enter an environment to configure this build for."
		fail
	elsif !File.exist?("Build/Settings/" + $env + ".yaml")
		puts "Cannot find configuration for #{$env} environment."
		puts "Try one of " + Dir.glob("Build\Settings\*.yaml").collect {|f| f[0...f.index('.')]}.to_s
		fail
	else				
		yml = ::Yamler.load("Build/Settings/" + $env + ".yaml")  		
        configatron.configure_from_hash(yml)
		
		puts "Configuring build for #{$env} environment."
	end
	
end


desc 'Configure application for  environment'
task :config_all_projects => :set_environment_variables do
  puts "Configure applications for environment"  
	Dir.glob("Build\Settings\**/*.configatron") do |filename|		
		str = File.read(filename)
		str = str.gsub(/#\{(configatron\..*)\}/) do |v| 
			c = eval($1)
			#puts $1, c
			if c.nil?
				puts "The config parameter #{$1} in #{filename} is missing from #{$env}.yaml"
				puts "Check your configuration files and re-run this task."
				fail
			end
			c
		end		
		
		filename["configatron"] = "config"		
		File.open(filename, 'w') { |f| f.write(str) }
	end
end